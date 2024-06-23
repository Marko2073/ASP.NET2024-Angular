using AspProjekat2024.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.DataAccess.Configurations
{
    internal class UserCartConfiguration : EntityConfiguration<UserCart>
    {
        public override void ConfigureEntity(EntityTypeBuilder<UserCart> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(x => x.UserCarts)
                .HasForeignKey(x => x.UserId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
