using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_system.Models;

namespace University_system
{
    public class UniversityContext : DbContext 
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Department> departments { get; set; }

        public DbSet<Instructor> instructors { get; set; }

        public DbSet<Student> students { get; set; }

        public DbSet<Enrollment> enrollments { get; set; }



        //database connection string
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
           options.UseSqlServer("Server=localhost;Database=UniversityDB;Trusted_Connection=True; TrustServerCertificate=True");
        }

    }
}
