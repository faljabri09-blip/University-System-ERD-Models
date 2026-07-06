using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_system.Models
{
    [Table("Users")] // Specify the table name in the database
    public class User
    {
        [Key] // Primary key && not null 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto generated
        public int userId { get; set; }

        [Required] // Not null
        //[Index(IsUniqu = true)] // Unique
        [MaxLength(50)] // Max length
        public string userName { get; set; }

        [Required] // Not null
        //[Index(IsUniqu = true)] // Unique
        [MaxLength(150)] // Max length
        public string email { get; set; }

        [Required] // Not null
        [MaxLength(265)] // Max length
        public string passwordHash { get; set; }

        [Required] // Not null
        [MaxLength(100)] // Max length

        public string fullName { get; set; }

        [MaxLength(20)]
        public string ? phoneNumber { get; set; } //optional

        [MaxLength(300)]
        public string ? address { get; set; } //optional

        [Required]
        public DateTime ? registrationDate { get; set; } = DateTime.Now;

        public bool isActive { get; set; } = true;

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public ICollection<Review> Reviews { get; set; } // Navigation property for related reviews
    }
}
