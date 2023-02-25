using Domain.Models;
using Domain.utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.DAL.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { 
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //DESKTOP-JD76U9C
            //LAPTOP-NNUMAB6J
            builder.UseSqlServer("Server=DESKTOP-JD76U9C;Database=Ecom;Trusted_Connection=True;Trust Server Certificate=true;");
        }
        
        DbSet<Users> Users { get; set; }
        DbSet<Roles> roles { get; set; }
        DbSet<Permessions> permessions { get; set; }
        DbSet<RolesPermission> rolesPermissions { get; set; }
        DbSet<Category> category { get; set; }
        DbSet<Brands> brands { get; set; }
        DbSet<Products> products { get; set; }
        DbSet<OrderStates> orderStates { get; set; }
        DbSet<ProductState> productState { get; set; }
        DbSet<Customer> customers { get; set; }
        DbSet<OrderItem> orderItems { get; set; }
        DbSet<Order> orders { get; set; }
       
    }
}
