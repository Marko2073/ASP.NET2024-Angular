using AspProjekat2024.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.DataAccess.Configurations
{
    internal class SpecificationConfiguration : EntityConfiguration<Specification>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Specification> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ParentId).HasDefaultValue(null);
            builder.HasOne(x => x.Parent).WithMany(x => x.Childrens).HasForeignKey(x => x.ParentId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            

        }
    }
}
