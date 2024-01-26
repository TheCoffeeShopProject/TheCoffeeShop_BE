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
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail");
            builder.HasKey(x => x.OrderDeatailID);
            builder.Property(x => x.OrderID).IsRequired();
            builder.Property(x => x.MenuID).IsRequired();


            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            


        }
    }
}
