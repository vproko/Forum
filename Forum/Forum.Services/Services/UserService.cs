using AutoMapper;
using Forum.DataAccess.Interfaces;
using Forum.DomainClasses.Models;
using Forum.Services.Interfaces;
using Forum.ViewModels.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> _userRepo;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public UserService(IUserRepository<User> userRepo, UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userRepo = userRepo;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task RegisterAsync(RegisterViewModel registerModel, string role)
        {
            if (_userRepo.GetByUsername(registerModel.Username) != null)
                throw new Exception("Username already exists!");

            if (registerModel.Password != registerModel.ConfirmPassword)
                throw new Exception("Passwords does not match!");

            User user = _mapper.Map<User>(registerModel);

            if (role == "admin") user.Administrator = true;

            user.Avatar = "/avatars/no-image.jpg";

            IdentityResult identityResponse = await _userManager.CreateAsync(user, registerModel.Password);

            if (identityResponse.Succeeded)
            {
                User currentUser = await _userManager.FindByNameAsync(user.UserName);
                var result = _userManager.AddToRoleAsync(currentUser, role).Result;

                if (result.Succeeded && role != "admin")
                {
                    await LoginAsync(new LoginViewModel { Username = registerModel.Username, Password = registerModel.Password });
                    await UserOnlineStatusAsync(currentUser.UserName, true);
                }
            }
            else
                throw new Exception(identityResponse.Errors.ToString());
        }

        public async Task<bool> LoginAsync(LoginViewModel loginModel)
        {
            SignInResult signInRes = await _signInManager.PasswordSignInAsync(loginModel.Username, loginModel.Password, false, false);

            if (signInRes.Succeeded) return true;

            return false;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
        {
            return await Task.Run(() => _mapper.Map<IEnumerable<UserViewModel>>(_userRepo.GetAll().OrderBy(u => u.UserName)));
        }

        public async Task<UserViewModel> GetCurrentUserAsync(string username)
        {
            User user = await Task.Run(() => _userRepo.GetByUsername(username));

            if (user != null)
                return _mapper.Map<UserViewModel>(user);
            else
                throw new Exception("There's no user with that username");
        }

        public async Task UserOnlineStatusAsync(string username, bool status)
        {
            User user = await Task.Run(() => _userRepo.GetByUsername(username));

            if (user != null)
            {
                user.Online = status;
                _userRepo.Update(user);
            }
            else
                throw new Exception("There's no user with that username");
        }

        public async Task UpdateUserInfoAsync(UpdateUserViewModel update)
        {
            User user = await _userManager.FindByIdAsync(update.UserID);

            if (user != null)
            {
                var fullName = user.FullName.Split(' ');
                string name = !String.IsNullOrEmpty(update.FirstName) ? update.FirstName : fullName[0];
                string surname = !String.IsNullOrEmpty(update.LastName) ? update.LastName : fullName[1];

                user.FullName = $"{name} {surname}";
                user.Email = !String.IsNullOrEmpty(update.Email) ? update.Email : user.Email;

                if (update.NewPassword != null)
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(null, update.NewPassword);

                await Task.Run(() => _userRepo.Update(user));
            }
            else
                throw new Exception("There's no user with that id");
        }

        public async Task PasswordCheckAsync(string password, string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                bool checkPassword = await _userManager.CheckPasswordAsync(user, password);

                if (!checkPassword)
                    throw new Exception("Wrong password");
            }
            else
                throw new Exception("There's no user with that id");
        }

        public async Task UpdateAvatarAsync(UserViewModel user)
        {
            int result = await Task.Run(() => _userRepo.Update(_mapper.Map<User>(user)));

            CheckForError(result);
        }

        public async Task SuspensionStatusAsync(string username)
        {
            User user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                user.Suspended = !user.Suspended;
                int result = await Task.Run(() => _userRepo.Update(user));
                CheckForError(result);
            }
            else
                throw new Exception("There's no user with that username");
        }

        public async Task LogoutAsync() => await _signInManager.SignOutAsync();

        public async Task DeleteUserAsync(string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);

            if (user != null)
                await _userManager.DeleteAsync(user);
            else
                throw new Exception("There's no user with that ID");
        }

        private void CheckForError(int result)
        {
            if (result == -1)
                throw new Exception("Something went wrong");
        }
    }
}
