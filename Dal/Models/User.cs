using System;
using System.ComponentModel.DataAnnotations;

namespace Dal.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required, MaxLength(50)]
        public string? UserName { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string? Email { get; set; }


        [Required]
        public string? PasswordHash { get; set; }


        public string? PasswordSalt { get; set; }

        public string? Role { get; set; } = "User";

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsEmailConfirmed { get; set; } = false;


    }
}