using Forum.Dto.Models;
using Forum.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersPerPageAsync(int pageIndex, int pageSize);
        Task<IEnumerable<UserDto>> SearchUsersPerPageAsync(string searchTerm, int pageIndex, int pageSize);
        Task<UserDto> FindUserAsync(Guid id);
        Task<UserDto> FindUserAsync(string username);
        Task<UserDto> GetUsersMessagesAsync(string username, int pageIndex, int pageSize);
        Task<bool> CreateAsync(RegistrationViewModel newUser);
        Task<UserDto> UpdateUserAsync(UpdateInfoViewModel user, string username);
        Task<bool> ChangeUsersPasswordAsync(ChangePasswordViewModel password, string username);
        Task ChangeUsersSuspensionAsync(Guid userId);
        Task<bool> RemovedByAdminAsync(string username);
        Task<bool> RemoveAsync(string username);
        Task<bool> LogInAsync(LoginViewModel login);
        Task LogOutAsync(string username);
    }
}