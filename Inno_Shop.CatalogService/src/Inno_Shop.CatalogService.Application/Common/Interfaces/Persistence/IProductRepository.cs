using Inno_Shop.CatalogService.Domain.Entities;

namespace Inno_Shop.CatalogService.Application.Common.Interfaces.Persistence;

public interface IProductRepository
{
	IQueryable<Product> GetAllProducts();

	Task<IList<Product>> GetProductsByUserId(Guid userId);

	Task<Product> GetByProductId(string id);

	Task CreateProduct(Product product);

	Task UpdateProduct(Product product);

	Task DeleteProduct(Product product);
}