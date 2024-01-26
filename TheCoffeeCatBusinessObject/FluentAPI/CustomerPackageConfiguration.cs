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
    public class CustomerPackageConfiguration : IEntityTypeConfiguration<CustomerPackage>
    {
        public void Configure(EntityTypeBuilder<CustomerPackage> builder)
        {
            builder.ToTable("CustomerPackage");
            builder.HasKey(x => x.CPID);
            builder.Property(x => x.DateStart).IsRequired();
            builder.Property(x => x.DateEnd).IsRequired();

        }
    }
}
