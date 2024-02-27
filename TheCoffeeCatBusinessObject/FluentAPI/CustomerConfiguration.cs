using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatBusinessObject.FluentAPI
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(x => x.CustomerID);
            builder.Property(x => x.FullName).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
        
            builder.HasMany(x => x.CustomerPackages).WithOne(x => x.Customer).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Comments).WithOne(x => x.Customer).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Account);




        }
    }
}
