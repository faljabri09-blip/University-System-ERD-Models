using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_system.Models
{
    public class Department
    {
        [Key] // primary key
        [Required] // not null
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // auto generated
        public int departmentId { get; set; }

        [Required]
        //[Index(IsUnique == true)] // unique
        public string departmentName { get; set; }

        [MaxLength(50)]
        public string ? building { get; set; }

        [Required]
        [Range(typeof (decimal) , "0.01" , "99999.99" , ErrorMessage = "Salary must be greater than 0")] // budget must be greater than 0
        public decimal budget { get; set; }

        [ForeignKey("Instructor")] // foreign key to Instructor entity
        public int ? headOfInstructorId { get; set; } //nullable (department may not have a head yet)

    }
}
