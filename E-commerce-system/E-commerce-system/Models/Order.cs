using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_system.Models
{
    public class Order
    {
        [Key] // Primary key 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto generated
        [Required] // Not null
        public int orderId { get; set; }

        [ForeignKey("User")] // Foreign key to User
        [Required] // Not null
        public int userId { get; set; } // Foreign key to User

        [Required]
        public DateTime orderDate { get; set; } // Date of the order

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Value must be greater than or equal to 0")]
        public decimal totalAmount { get; set; } // Total amount of the order

        [Required]
        public string status { get; set; } = "Pending"; // default value is "Pending"


        [Required]
        [MaxLength(300)]
        public string shippingAddress { get; set; }

        [Required]
        [MaxLength(50)]
        public string paymentMethod { get; set; } 

        public ICollection<product> Products { get; set; } // Navigation property for related products
    }
}
