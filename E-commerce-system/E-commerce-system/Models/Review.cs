using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_system.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int reviewId { get; set; }

        [ForeignKey("User")] // Foreign key to the User table
        [Required]
        public int userId { get; set; }

        [ForeignKey("Product")] // Foreign key to the Product table
        [Required]
        public int productId { get; set; }


        [Required]
        [Range(1,5)] // Rating should be between 1 and 5
        public int rating { get; set; } // Rating given by the user

        [MaxLength(1000)]
        public string? comment { get; set; } // Optional 

        [Required]
        public DateTime reviewDate { get; set; } = DateTime.Now; // Timestamp of when the review was created

        public product product { get; set; } // Navigation property for related product
    }
}
