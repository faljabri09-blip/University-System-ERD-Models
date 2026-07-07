using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce_Solution.Models
{
    [Table("ProductOrders")] // Table name in the database
    public class ProductOrder
    {
        [Key] // Primary key && not nu
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto generated
        public int ProductOrderId { get; set; } // Foreign key to Product

        [ForeignKey("Order")] // Foreign key to Order
        [Required]
        public int orderId { get; set; } // Foreign key to Order
        public Order Order { get; set; } // Navigation property for related order


        [ForeignKey("product")] // Foreign key to Product
        [Required]
        public int productId { get; set; } // Foreign key to Product
        public product product { get; set; } // Navigation property for related product

        [Required] // Not null
        [Range(1, 999)] // Quantity should be between 1 and 999
        public int quantity { get; set; } // Quantity of the product in the order

        [Required]
        public decimal unitPrice { get; set; }




    }
}
