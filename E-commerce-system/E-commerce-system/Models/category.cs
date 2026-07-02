using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_system.Models
{
    public class category
    {
        [Key] // primary key && not null 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // auto generated
        public int categoryId { get; set; }

        [Required] // not null
        //[Index(IsUnique = true)] // unique
        [MaxLength(100)] // max length
        public string categoryName { get; set; }

        [MaxLength(500)] // max length
        public string ? description { get; set; } // optional

        [MaxLength(300)] // max length
        public string ? imageUrl { get; set; } // optional

        public ICollection<product> Products { get; set; } // Navigation property for related products
    }
}
