using MemberSystem.Api.Models;

namespace MemberSystem.Api.Service
{
     public interface IUserService
     {
          Task<User> RegisterAsync(User user, string password);

          Task<User?> LoginAsync(string email, string password);

          Task<User?> GetUserByIdAsync(int id);
     }
}
