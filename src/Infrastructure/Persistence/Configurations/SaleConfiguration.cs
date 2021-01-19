using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.Property(s => s.ArticleNumber)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(s => s.Price).HasPrecision(15, 2);

            // Apply other configurations if needed
            // (e.g. sales price cannot be negative, indices, etc.)
        }
    }
}
