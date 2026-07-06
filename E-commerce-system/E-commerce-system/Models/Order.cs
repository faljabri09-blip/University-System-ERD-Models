using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce_Solution.Models
{
    [Table("Orders")] // Table name in the database
    public class Order
    {
        [Key] // Primary key && not null 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto generated
        public int orderId { get; set; }


        [ForeignKey("User")] // Foreign key to User
        [Required] // Not null
        public int userId { get; set; } // Foreign key to User

        [Required]
        public DateTime orderDate { get; set; } // Date of the order

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal totalAmount { get; set; } // Total amount of the order

        [Required]
        public string status { get; set; } = "Pending"; // default value is "Pending"


        [Required]
        [MaxLength(300)]
        public string shippingAddress { get; set; }

        [Required]
        [MaxLength(50)]
        public string paymentMethod { get; set; }

        public User User { get; set; }// Navigation property 
        public ICollection<ProductOrder> ProductOrders { get; set; } 

    }
}
