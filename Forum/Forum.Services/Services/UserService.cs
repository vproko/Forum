using AutoMapper;
using Forum.DataAccess.Interfaces;
using Forum.DomainClasses.Models;
using Forum.Dto.Models;
using Forum.Services.Interfaces;
using Forum.ViewModels.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Services.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IReplyService _replyService;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, IReplyService replyService) : base(unitOfWork, mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _replyService = replyService;
        }

        public async Task<bool> CreateAsync(RegistrationViewModel newUser)
        {
            if (await UserCheckAsync(newUser)) // Checking if the user already exist, and if the password is properly entered
            {
                Guid? userReg = await UserRegistrationAsync(newUser);
                if (userReg != null)
                {
                    if (await LogInAsync(new LoginViewModel { UserName = newUser.UserName, Password = newUser.Password }))
                        await ChangeUserOnlineStatusAsync((Guid)userReg);
                    return true;
                }
            }
            return false;
        }

        private async Task<Guid?> UserRegistrationAsync(RegistrationViewModel newUser)
        {
            User user = _mapper.Map<User>(newUser);
            IdentityResult identityResult = await _userManager.CreateAsync(user, newUser.Password); // Creating new user in the user's store
            if (identityResult.Succeeded)
            {
                User currentUser = await _userManager.FindByNameAsync(user.UserName); // Finding the newly created user from the user's store
                IdentityResult result = await _userManager.AddToRoleAsync(currentUser, "user"); // Adding role to the newly created user in the user's store

                if (result.Succeeded)
                    return currentUser.Id;
            }
            return null;
        }

        public async Task<bool> LogInAsync(LoginViewModel login)
        {
            SignInResult signIn = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);
            if (signIn.Succeeded)
            {
                User user = await _userManager.FindByNameAsync(login.UserName);
                await ChangeUserOnlineStatusAsync(user.Id);
                return true;
            }
            return false;
        }

        private async Task ChangeUserOnlineStatusAsync(Guid userId)
        {
            User user = await _unitOfWork.Users.FindAsync(userId);
            if (user != null)
            {
                user.Online = !user.Online;
                await _unitOfWork.CompleteAsync();
            }
            if (user is null)
                throw new Exception("There's no user with that username");
        }

        public async Task LogOutAsync(string username)
        {
            User user = await _userManager.FindByNameAsync(username);
            await ChangeUserOnlineStatusAsync(user.Id);
            await _signInManager.SignOutAsync();
        }

        public async Task<IEnumerable<UserDto>> GetUsersPerPageAsync(int pageIndex, int pageSize)
        {
            return _mapper.Map<IEnumerable<UserDto>>(await _unitOfWork.Users.GetUsersInfoAsync(pageIndex, pageSize));
        }
        
        public async Task<IEnumerable<UserDto>> SearchUsersPerPageAsync(string searchTerm, int pageIndex, int pageSize)
        {
            return _mapper.Map<IEnumerable<UserDto>>(await _unitOfWork.Users.GetUsersInfoBySearchAsync(searchTerm, pageIndex, pageSize));
        }

        public async Task<UserDto> GetUsersMessagesAsync(string username, int pageIndex, int pageSize)
{
            return _mapper.Map<UserDto>(await _unitOfWork.Users.GetUsersMessagesAsync(username, pageIndex, pageSize));
        }

        public async Task<UserDto> FindUserAsync(Guid id)
{
            return _mapper.Map<UserDto>(await _unitOfWork.Users.FindUserInfoAsync(id));
        }

        public async Task<UserDto> FindUserAsync(string username)
        {
            return _mapper.Map<UserDto>(await _userManager.FindByNameAsync(username));
        }

        public async Task ChangeUsersSuspensionAsync(Guid userId)
        {
            User user = await _unitOfWork.Users.FindAsync(userId);
            user.Suspended = !user.Suspended;
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> RemoveAsync(string username)
        {
            User match = await _userManager.FindByNameAsync(username);
            await _replyService.DeleteUsersRepliesAsync(match.Id);
            await _signInManager.SignOutAsync();
            await Task.Run(() => _unitOfWork.Users.Remove(match));
            return (await _unitOfWork.CompleteAsync() > 0);
        }
        
        public async Task<bool> RemovedByAdminAsync(string username)
        {
            User match = await _userManager.FindByNameAsync(username);
            await Task.Run(() => _unitOfWork.Users.Remove(match));
            return (await _unitOfWork.CompleteAsync() > 0);
        }

        public async Task<UserDto> UpdateUserAsync(UpdateInfoViewModel user, string username)
        {
            User match = await _userManager.FindByNameAsync(username);
            match.Avatar = string.IsNullOrEmpty(user.Avatar) ? match.Avatar : user.Avatar;
            match.FirstName = string.IsNullOrEmpty(user.FirstName) ? match.FirstName : user.FirstName;
            match.LastName = string.IsNullOrEmpty(user.LastName) ? match.LastName : user.LastName;
            match.Email = string.IsNullOrEmpty(user.Email) ? match.Email : user.Email;
            match.NormalizedEmail = string.IsNullOrEmpty(user.Email) ? match.NormalizedEmail : user.Email.ToUpper();
            if (await _unitOfWork.CompleteAsync() > 0)
                return _mapper.Map<UserDto>(match);
            return null;
        }

        public async Task<bool> ChangeUsersPasswordAsync(ChangePasswordViewModel password, string username)
        {
            if (!string.IsNullOrEmpty(password.OldPassword) && !string.IsNullOrEmpty(password.NewPassword) && !string.IsNullOrEmpty(password.ConfrimNewPassword))
            {
                if (password.NewPassword == password.ConfrimNewPassword)
                {
                    User match = await _userManager.FindByNameAsync(username);
                    if (await _userManager.CheckPasswordAsync(match, password.OldPassword))
                    {
                        match.PasswordHash = _userManager.PasswordHasher.HashPassword(null, password.NewPassword);
                        await _unitOfWork.CompleteAsync();
                        return true;
                    }
                }
            }
            return false;
        }

        private async Task<bool> UserCheckAsync(RegistrationViewModel newUser)
        {
            if (await _userManager.FindByNameAsync(newUser.UserName) is null)
                if (newUser.Password != null && newUser.Password == newUser.ConfirmPassword)
                    return true;
            return false;
        }
    }
}