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
    public class CoffeeShopConfiguration : IEntityTypeConfiguration<CoffeeShop>
    {
        public void Configure(EntityTypeBuilder<CoffeeShop> builder)
        {
            builder.ToTable("CoffeeShop");
            builder.HasKey(x => x.CoffeeID);
            builder.Property(x => x.CoffeeName).IsRequired();
            builder.Property(x => x.OpenTime).IsRequired();
            builder.Property(x => x.CloseTime).IsRequired();
            
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Image);

            builder.HasMany(x => x.Staffs).WithOne(x => x.CoffeeShop).HasForeignKey(x => x.CoffeeID).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Tables).WithOne(x => x.CoffeeShop).HasForeignKey(x => x.CoffeeID).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Cats).WithOne(x => x.CoffeeShop).HasForeignKey(x => x.CoffeeID).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Menus).WithOne(x => x.CoffeeShop).HasForeignKey(x => x.CoffeeID).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Comments).WithOne(x => x.CoffeeShop).HasForeignKey(x => x.CoffeeID).OnDelete(DeleteBehavior.NoAction);






        }
    }
}
