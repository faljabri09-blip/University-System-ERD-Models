using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace University_system.Models
{

    public class Student
    {
        [Key] //primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // auto generated
        [Required] //not null
        public int stusentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string fullname { get; set; }

        [Required]
        [MaxLength(150)]
        //[Index(IsUnique = true)]
        public string email { get; set; }

        [MaxLength(20)]
        public string ? phoneNumber { get; set; } // optional 

        [Required]
        public DateTime dateOfBirth { get; set; }

        [Required]
        [Range(2000 , 2023)]
        public int enrollmentYear { get; set; }


        [Range(0.0, 4.0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] // default value
        public decimal gpa { get; set; } 

        public ICollection<Course> Courses { get; set; } //navigation property

        public ICollection<Enrollment> Enrollments { get; set; } //navigation property
    }
}
