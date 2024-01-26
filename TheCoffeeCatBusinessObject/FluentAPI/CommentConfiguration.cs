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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");
            builder.HasKey(x => x.CommentID);
            builder.Property(x => x.CommentText).IsRequired();
            builder.Property(x => x.CreateTime).IsRequired();
            builder.Property(x => x.UpdateTime).IsRequired();

            builder.Property(x => x.Status).IsRequired();
           

        }
    }
}
