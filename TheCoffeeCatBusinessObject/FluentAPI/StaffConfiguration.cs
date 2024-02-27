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
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("Staff");
            builder.HasKey(x => x.StaffID);
   
            builder.Property(x => x.FullName).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.DOB).IsRequired();
            builder.HasOne(x => x.Account);
            builder.HasMany(x=> x.Orders).WithOne(x=> x.Staff).HasForeignKey(x=> x.StaffID).OnDelete(DeleteBehavior.Cascade);









        }
    }
}
