using MemberSystem.Api.Models;
using MemberSystem.Api.Repositories;
using BCrypt.Net;

namespace MemberSystem.Api.Service
{
     public class UserService : IUserService
     {
          private readonly IUserRepository _userRepository;
          public UserService(IUserRepository userRepository)
          {
               _userRepository = userRepository;
          }

          public Task<User?> GetUserByIdAsync(int id)
          {
               throw new NotImplementedException();
          }

          public async Task<User?> LoginAsync(string email, string password)
          {
               var user = await _userRepository.GetByEmailAsync(email);
               if (user == null) return null;

               bool isValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

               return isValid ? user : null;
          }

          public async Task<User> RegisterAsync(User user, string password)
          {
               //1. Check if user with email already exists
               var existingUser = await _userRepository.GetByEmailAsync(user.Email);
               if (existingUser != null) throw new Exception("User with this email already exists.");

               //2.password
               user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password); 
               user.CreatedAt = DateTime.UtcNow;

               //3. Add user to repository
               await _userRepository.AddAsync(user);
               await _userRepository.SaveChangesAsync();
               return user;
          }
     }
}
