using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_system.Models
{
    public class ProductOrder
    {
        [Key] // Primary key
        [Required] // Not null
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto generated
        public int productOrderId { get; set; } // Foreign key to Product

        [ForeignKey("Order")] // Foreign key to Order
        public int orderId { get; set; } // Foreign key to Order

        [ForeignKey("Product")] // Foreign key to Product
        public int productId { get; set; } // Foreign key to Product

        [Required] // Not null
        [Range(1, 999)] // Quantity should be between 1 and 999
        public int quantity { get; set; } // Quantity of the product in the order

        public Order Order { get; set; } // Navigation property for related order
        public product Product { get; set; } // Navigation property for related product
    }
}
