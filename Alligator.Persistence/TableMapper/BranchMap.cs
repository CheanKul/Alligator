using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Alligator.Domain.Model;

namespace Alligator.Persistence
{
    public class BranchMap : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("tblBranch");
            builder.Property(b => b.BranchId).HasColumnName("Id");
            builder.Property(b => b.Name).HasColumnName("Name");
            builder.Property(b => b.Address).HasColumnName("Address");
            builder.Property(b => b.Email).HasColumnName("Email");
            builder.Property(b => b.Contact).HasColumnName("Contact");
        }
    }
}
