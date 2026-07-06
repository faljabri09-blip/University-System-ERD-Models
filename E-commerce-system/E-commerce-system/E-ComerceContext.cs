using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ECommerce_Solution.Models;

namespace ECommerce_Solution
{
    public class E_ComerceContext : DbContext
    {

        public DbSet<product> Products { get; set; }
        public DbSet<category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost;Database=E_commerceDB;Trusted_Connection=True; TrustServerCertificate=True");

        }


    }

    
}
