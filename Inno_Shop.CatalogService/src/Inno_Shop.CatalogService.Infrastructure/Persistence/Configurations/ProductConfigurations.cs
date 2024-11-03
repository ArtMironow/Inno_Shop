using Inno_Shop.CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inno_Shop.CatalogService.Infrastructure.Persistence.Configurations;

public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.HasKey(p => p.ProductId);

		builder.Property(p => p.ProductId).ValueGeneratedNever();

		builder.Property(p => p.ProductName).HasMaxLength(50);

		builder.Property(p => p.Description).HasMaxLength(100);

		builder.Property(p => p.Price).HasPrecision(18, 4);
		
		builder.Property(p => p.IsAvailable);
		builder.Property(p => p.UserId);
		builder.Property(p => p.CreatedDate);
	}
}
