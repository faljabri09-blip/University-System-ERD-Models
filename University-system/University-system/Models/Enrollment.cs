using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace University_system.Models
{
    public class Enrollment
    {
        [Key] //primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //auto generated
        [Required] //not null
        public int EnrollmentId { get; set; }

        [ForeignKey("Student")] //foreign key
        [Required] //not null
        public int StudentId { get; set; }

        [ForeignKey("Course")] //foreign key
        [Required] //not null
        public int CourseId { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [MaxLength(2)] //(e.x A+ , A, B, C, D, F) 
        public string ? finalGrade { get; set; }

        [Required]
        [MaxLength(20)]
        public string status { get; set; } = "In Progress"; //default value

       public Student Student { get; set; } //navigation property
    }
}
