﻿using AspProjekat2024.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.DataAccess.Configurations
{
    internal class ModelConfiguration : EntityConfiguration<Model>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Model> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.HasOne(x => x.Brand).WithMany(x => x.Models).HasForeignKey(x => x.BrandId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            
        }
    }
}
