using Forum.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Services.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterViewModel registerModel, string role);
        Task<bool> LoginAsync(LoginViewModel loginModel);
        Task<IEnumerable<UserViewModel>> GetAllUsersAsync();
        Task<UserViewModel> GetCurrentUserAsync(string username);
        Task UserOnlineStatusAsync(string username, bool status);
        Task UpdateUserInfoAsync(UpdateUserViewModel update);
        Task PasswordCheckAsync(string password, string userId);
        Task UpdateAvatarAsync(UserViewModel user);
        Task SuspensionStatusAsync(string username);
        Task LogoutAsync();
        Task DeleteUserAsync(string userId);
    }
}
