using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // adding constriants to the model

namespace University_system.Models
{
    public class Course
    {
        [Key] //primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //auto generated
        [Required] //not null
        public int courseId { get; set; }

        [Required] //not null
        //[Index(IsUnique = true)] //unique constraint
        [MaxLength(10)] //max length
        public string courseCode { get; set; }

        [Required] //not null
        [MaxLength(150)] //max length
        public string courseTitle { get; set; }

        [Required]
        [Range(1, 6)] //range constraint
        public int creditHours { get; set; }

        [ForeignKey("Department")] //foreign key
        [Required] //not null
        public int departmentId { get; set; } //foreign key

        [ForeignKey("Instructor")] //foreign key
        public int ? instructorId { get; set; } //foreign key // nullable a course may be unassigned 


        [Required] //not null
        [MaxLength(20)] //max length
        public string semesterOffered { get; set; } 

        public Department Department { get; set; } //navigation property

        public Instructor Instructor { get; set; } //navigation property

        public ICollection<Student> Students { get; set; } //navigation property

        public ICollection<Enrollment> Enrollments { get; set; } //navigation property
    }
}
