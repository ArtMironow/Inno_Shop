using Inno_Shop.CatalogService.Application.Common.Interfaces.Persistence;
using Inno_Shop.CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inno_Shop.CatalogService.Infrastructure.Persistence.Repositories;

public class ProductRepository(CatalogServiceDbContext dbContext) : IProductRepository
{
	private readonly CatalogServiceDbContext _dbContext = dbContext;
	public async Task CreateProduct(Product product)
	{
		await _dbContext.Products.AddAsync(product);
		await _dbContext.SaveChangesAsync();
	}

	public async Task DeleteProduct(Product product)
	{
		_dbContext.Products.Remove(product);
		await _dbContext.SaveChangesAsync();
	}

	public IQueryable<Product> GetAllProducts()
	{
		var result = _dbContext.Products.AsQueryable();
		return result!;
	}

	public async Task<Product> GetByProductId(string id)
	{
		bool isValid = Guid.TryParse(id, out Guid guidOutput);

		if (!isValid)
		{
			return null!;
		}

		var product = await _dbContext.Products.Where(x => x.ProductId == new Guid(id)).FirstOrDefaultAsync();
		return product!;
	}

	public async Task<IList<Product>> GetProductsByUserId(Guid userId)
	{
		var result = await _dbContext.Products.Where(x => x.UserId == userId).ToListAsync();
		return result;
	}

	public async Task UpdateProduct(Product product)
	{
		_dbContext.Products.Update(product);
		await _dbContext.SaveChangesAsync();
	}
}