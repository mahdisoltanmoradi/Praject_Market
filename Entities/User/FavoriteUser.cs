using Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Entities.User
{
    public class FavoriteUser : BaseEntity<int>
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
    public class ProductConfiguration : IEntityTypeConfiguration<FavoriteUser>
    {
        public void Configure(EntityTypeBuilder<FavoriteUser> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
