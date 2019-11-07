using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Alligator.Domain.Model;

namespace Alligator.Persistence
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("tblProduct");
            builder.Property(b => b.ProductId).HasColumnName("ProductId");
            builder.Property(b => b.Name).HasColumnName("Name");
            builder.Property(b => b.Discription).HasColumnName("Discription");
            builder.Property(b => b.ImagePath).HasColumnName("ImagePath");
            builder.Property(b => b.Active).HasColumnName("Active");
            builder.Property(b => b.SellingPrice).HasColumnName("SellingPrice");
            builder.Property(b => b.CostPrice).HasColumnName("CostPrice");
        }
    }
}
