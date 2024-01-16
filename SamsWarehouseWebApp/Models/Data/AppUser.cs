using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SamsWarehouseWebApp.Models.Data
{
    public class AppUser //IdentityUser
    {
        [Key]
        public int UserId { get; set; }
        [Column("PasswordHash")]
        [StringLength(100)]
        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }
        public string? Role { get; set; }
        public virtual ICollection<List> Lists { get; set; }
    }
}
