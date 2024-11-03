using Inno_Shop.CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inno_Shop.CatalogService.Infrastructure.Persistence;

public class CatalogServiceDbContext : DbContext
{
	public CatalogServiceDbContext(DbContextOptions<CatalogServiceDbContext> options)
		: base(options)
	{
		Database.EnsureCreated();
	}

	public DbSet<Product> Products { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogServiceDbContext).Assembly);

		base.OnModelCreating(modelBuilder);
	}
}