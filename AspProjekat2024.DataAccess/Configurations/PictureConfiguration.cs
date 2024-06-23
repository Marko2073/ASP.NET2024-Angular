using AspProjekat2024.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.DataAccess.Configurations
{
    internal class PictureConfiguration : EntityConfiguration<Picture>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Picture> builder)
        {
            builder.Property(x => x.Path).IsRequired();
            builder.HasOne(x => x.ModelVersion).WithMany(x => x.Pictures).HasForeignKey(x => x.ModelVersionId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
