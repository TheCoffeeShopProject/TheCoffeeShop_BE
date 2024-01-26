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
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("Subscription");
            builder.HasKey(x => x.SubscriptionID);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.DiscountPercent).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.HasMany(x => x.CustomerPackages).WithOne(x => x.Subscription).OnDelete(DeleteBehavior.NoAction);


        }
    }
}