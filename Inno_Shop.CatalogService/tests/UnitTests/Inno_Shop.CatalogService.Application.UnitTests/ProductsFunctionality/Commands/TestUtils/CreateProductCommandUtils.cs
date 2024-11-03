using Inno_Shop.CatalogService.Application.ProductsFunctionality.Commands.CreateProduct;
using Inno_Shop.CatalogService.Application.UnitTests.ProductsFunctionality.TestUtils.Constants;

namespace Inno_Shop.CatalogService.Application.UnitTests.ProductsFunctionality.Commands.TestUtils;

public class CreateProductCommandUtils()
{
	public static CreateProductCommand CreateCommand(string? productName = null) =>
		new(
			productName ?? Constants.Product.ProductName,
			Constants.Product.Description,
			Constants.Product.Price,
			Constants.Product.IsAvailable,
			Guid.NewGuid().ToString()
		);
}