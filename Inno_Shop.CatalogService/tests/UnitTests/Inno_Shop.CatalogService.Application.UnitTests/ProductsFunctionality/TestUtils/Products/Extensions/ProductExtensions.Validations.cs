using FluentAssertions;
using Inno_Shop.CatalogService.Application.ProductsFunctionality.Commands.CreateProduct;
using Inno_Shop.CatalogService.Domain.Entities;

namespace Inno_Shop.CatalogService.Application.UnitTests.ProductsFunctionality.TestUtils.Products.Extensions;

public static partial class ProductExtensions
{
	public static void ValidateCreatedFrom(this Product product, CreateProductCommand createProductCommand)
	{
		product.ProductId.Should().NotBeEmpty();
		product.ProductName.Should().Be(createProductCommand.ProductName);
		product.Description.Should().Be(createProductCommand.Description);
		product.Price.Should().Be(createProductCommand.Price);
		product.IsAvailable.Should().Be(createProductCommand.IsAvailable);
		product.UserId.Should().NotBeEmpty();
	}
}