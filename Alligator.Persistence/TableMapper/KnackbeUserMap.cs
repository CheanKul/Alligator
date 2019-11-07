using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Alligator.Domain.Model;

namespace Alligator.Persistence
{
    class KnackbeUserMap : IEntityTypeConfiguration<KnackbeUser>
    {
        public void Configure(EntityTypeBuilder<KnackbeUser> builder)
        {
            builder.ToTable("tblKnackbeUser");
            builder.Property(b => b.Id).HasColumnName("Id");
            builder.Property(b => b.Name).HasColumnName("Name");
            builder.Property(b => b.Username).HasColumnName("Username");
            builder.Property(b => b.Password).HasColumnName("Password");
            builder.Property(b => b.Address).HasColumnName("Address");
        }
    }
}
