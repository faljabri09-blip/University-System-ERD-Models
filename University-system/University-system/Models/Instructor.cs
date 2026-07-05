using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_system.Models
{
    public class Instructor
    {
        [Key] // Primary key && not null
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // auto generated
        public int instructorId { get; set; }

        [Required]
        [MaxLength(100)] // Limits the length of the full name to 100 characters
        public string fullname { get; set; }

        [Required]
        //[Index(IsUnique = true)] // Ensures that the email is unique across all instructors
        [MaxLength(150)]
        public string email { get; set; }

        [MaxLength(20)] // Limits the length of the phone number to 20 characters
        public string ? officeNumber { get; set; } //optional

        [Required]
        public DateTime hireDate { get; set; }

        [Required]
        [Range(0.01 , double.MaxValue)] // salary must be greater than 0
        public decimal InstructorSalary { get; set; }


        [Required]
        [MaxLength(50)] // Limits the length of the academic title to 50 characters
        public string academicTitle { get; set; }

        public Department Department { get; set; } // navigation (Relationship) property to Department entity

        public ICollection<Instructor> Instructors { get; set; } // navigation (Relationship) property
    }
}
