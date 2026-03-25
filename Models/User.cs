using System.ComponentModel.DataAnnotations;

namespace MemberSystem.Api.Models
{
     public class User
     {
          [Key]
          public int Id { get; set; }

          [Required]
          [MaxLength(100)]
          public string Name { get; set; }

          [Required]
          [MaxLength(100)]
          public string Email { get; set; }

          [Required]
          [MaxLength(100)]
          public string PasswordHash { get; set; }

          [Required]
          public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


     }
}
