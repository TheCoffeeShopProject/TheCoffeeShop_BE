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
    public class DrinkConfiguration : IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder)
        {
            builder.ToTable("Drink");
            builder.HasKey(x => x.DrinkID);
            builder.Property(x => x.DrinkName).IsRequired();
            builder.Property(x => x.UnitPrice).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Image);
            builder.HasMany(x => x.Menus).WithOne(x => x.Drink).OnDelete(DeleteBehavior.NoAction);





        }
    }
}
