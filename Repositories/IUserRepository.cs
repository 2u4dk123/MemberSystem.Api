using MemberSystem.Api.Models;

namespace MemberSystem.Api.Repositories
{
     public interface IUserRepository
     {
          Task<User?> GetByEmailAsync(string email);
          Task<User> AddAsync(User user);
          Task<bool> SaveChangesAsync();

     }
}
