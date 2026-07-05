using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_system.Models
{
    public class product
    {
        [Key] // Primary key && not null 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto generated
        public int productId { get; set; }


        [Required] // Not null
        [MaxLength(150)] // Max length 150 
        public string productName { get; set; }

        [MaxLength(1000)] // Max length 1000
        public string ? description { get; set; } //optional

        [Required] // Not null
        [Range(0.01 , double.MaxValue)] // Price must be greater than 0
        public decimal price { get; set; }

        [Required] // Not null
        [Range(0, int.MaxValue)]
        public int stockQuantity { get; set; } = 0; // Stock quantity //default value 0

        [MaxLength(300)] // Max length 300 (max length of a URL)
        public string ? imageUrl { get; set; } //optional

        [ForeignKey("category")] // Foreign key
        [Required] // Not null
        public int categoryId { get; set; } // Foreign key

        [Required] // Not null
        public DateTime createAt { get; set; }

        public bool isAvailable { get; set; } = true; //default value true

        public User User { get; set; } // Navigation property for related user

        public ICollection<ProductOrder> ProductOrders { get; set; }
        public category category { get; set; } // Navigation property for related category

        public List<Review > Reviews { get; set; } // Navigation property for related review
    }
}
