using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Alligator.Domain.Model;

namespace Alligator.Persistence
{
    class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("tblCompany");
            builder.Property(b => b.CompanyId).HasColumnName("Id");
            builder.Property(b => b.CompanyName).HasColumnName("Name");
            builder.Property(b => b.Address).HasColumnName("Address");
            builder.Property(b => b.Email).HasColumnName("Email");
            builder.Property(b => b.Contact).HasColumnName("Contact");
            builder.Property(b => b.Pincode).HasColumnName("Pincode");
            builder.Property(b => b.Username).HasColumnName("Username");
            builder.Property(b => b.Password).HasColumnName("Password");
        }
    }
}
