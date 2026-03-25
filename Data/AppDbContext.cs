using Microsoft.EntityFrameworkCore;
using MemberSystem.Api.Models;

namespace MemberSystem.Api.Data
{
     public class AppDbContext : DbContext
     {
          public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
          {
          }

          public DbSet<User> Users { get; set; }
     }
}
