using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(u => u.Title).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Description).IsRequired().HasMaxLength(200);
            builder.Property(u => u.Image).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(u => u.Price).IsRequired();
            builder.Property(u => u.Rate).IsRequired();
            builder.Property(u => u.RatingCount).IsRequired();

            builder.Property(u => u.Category)
                .HasConversion<string>()
                .HasMaxLength(20);
        }
    }
}
