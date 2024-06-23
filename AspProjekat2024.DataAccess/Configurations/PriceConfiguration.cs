using AspProjekat2024.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.DataAccess.Configurations
{
    internal class PriceConfiguration : EntityConfiguration<Price>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Price> builder)
        {
            builder.Property(x => x.PriceValue).IsRequired().HasPrecision(8,2);
            builder.Property(x => x.DateFrom).IsRequired();
            builder.Property(x => x.DateTo).IsRequired();
            builder.HasOne(x => x.ModelVersion).WithMany(x => x.Prices).HasForeignKey(x => x.ModelVersionId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
