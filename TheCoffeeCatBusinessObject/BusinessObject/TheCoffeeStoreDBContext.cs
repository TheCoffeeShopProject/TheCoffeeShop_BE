using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.BusinessObject
{
    public class TheCoffeeStoreDBContext : DbContext
    {
        public TheCoffeeStoreDBContext()
        {

        }
        public TheCoffeeStoreDBContext(DbContextOptions<TheCoffeeStoreDBContext> opt) : base(opt) { }


        public virtual DbSet<Role>? Roles { get; set; }
        public virtual DbSet<Account>? Accounts { get; set; }
        public virtual DbSet<Comment>? Comments { get; set; }
        public virtual DbSet<Cat>? Cats { get; set; }
        public virtual DbSet<CatProduct>? CatProducts { get; set; }
        public virtual DbSet<CoffeeShop>? CofffeeShops { get; set; }
        public virtual DbSet<Customer>? Customers { get; set; }
        public virtual DbSet<Drink>? Drinks { get; set; }

        public virtual DbSet<Menu>? Menus { get; set; }
        public virtual DbSet<Staff>? Staffs { get; set; }

        public virtual DbSet<Subscription>? Subscriptions { get; set; }
        public virtual DbSet<CustomerPackage>? CustomerPackages { get; set; }

        public virtual DbSet<Table>? Tables { get; set; }

        public virtual DbSet<Order>? Orders { get; set; }

        public virtual DbSet<OrderDetail>? OrderDetails { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            return config["ConnectionStrings:DB"]!;
        }
    }
}
