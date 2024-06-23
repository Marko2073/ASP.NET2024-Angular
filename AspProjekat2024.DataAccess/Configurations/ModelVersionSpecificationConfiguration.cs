using AspProjekat2024.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.DataAccess.Configurations
{
    internal class ModelVersionSpecificationConfiguration : EntityConfiguration<ModelVersionSpecification>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ModelVersionSpecification> builder)
        {
            builder.HasOne(x => x.ModelVersion).WithMany(x => x.ModelVersionSpecifications).HasForeignKey(x => x.ModelVersionId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(x => x.Specification).WithMany(x => x.ModelVersionSpecifications).HasForeignKey(x => x.SpecificationId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            
        }
    }
}
