using AspProjekat2024.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.DataAccess.Configurations
{
    internal class ModelVersionConfiguration : EntityConfiguration<ModelVersion>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ModelVersion> builder)
        {
            builder.Property(x => x.StockQuantity).IsRequired();
            builder.HasOne(x => x.Model).WithMany(x => x.ModelVersions).HasForeignKey(x => x.ModelId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            
        }
    }
}
