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
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");
            builder.HasKey(x => x.MenuID);
            builder.Property(x => x.CatProductID);
            builder.Property(x => x.CoffeeID).IsRequired();

            builder.Property(x => x.DrinkID);
            builder.Property(x => x.Status).IsRequired();
            builder.HasMany(x => x.OrderDetails).WithOne(x => x.Menu).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
