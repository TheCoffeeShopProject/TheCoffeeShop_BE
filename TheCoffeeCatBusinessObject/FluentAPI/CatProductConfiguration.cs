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
    public class CatProduceConfiguration : IEntityTypeConfiguration<CatProduct>
    {
        public void Configure(EntityTypeBuilder<CatProduct> builder)
        {
            builder.ToTable("CatProduct");
            builder.HasKey(x => x.CatProductID);
            builder.Property(x => x.CatProductName).IsRequired();
            builder.Property(x => x.CatProductType).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Image);
            builder.Property(x => x.Status).IsRequired();
            builder.HasMany(x => x.Menus).WithOne(x => x.CatProduct).OnDelete(DeleteBehavior.NoAction);




        }
    }
}
