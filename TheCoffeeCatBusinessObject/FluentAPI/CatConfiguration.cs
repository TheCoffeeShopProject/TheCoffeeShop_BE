using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatBusinessObject.FluentAPI
{
    public class CatConfiguration : IEntityTypeConfiguration<Cat>
    {
        public void Configure(EntityTypeBuilder<Cat> builder)
        {
            builder.ToTable("Cat");
            builder.HasKey(x => x.CatID);
            builder.Property(x => x.CatName).IsRequired();
            builder.Property(x => x.Age);
            builder.Property(x => x.Description);
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Image);
            
        }
    }
}
