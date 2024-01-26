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
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.ToTable("Table");
            builder.HasKey(x => x.TableID);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Type).IsRequired();
          
            builder.HasMany(x => x.Orders).WithOne(x => x.Table).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
