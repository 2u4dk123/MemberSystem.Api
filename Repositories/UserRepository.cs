using MemberSystem.Api.Data;
using MemberSystem.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MemberSystem.Api.Repositories
{
     public class UserRepository : IUserRepository
     {
          private readonly AppDbContext _context;
          public UserRepository(AppDbContext context)
          {
               _context = context;
          }
          public async Task<User> AddAsync(User user)
          {
               await _context.Users.AddAsync(user);
               return user;
          }

          public async Task<User?> GetByEmailAsync(string email)
          {
               return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
          }

          public async Task<bool> SaveChangesAsync()
          {
               return (await _context.SaveChangesAsync()) >= 0;
          }
     }
}
