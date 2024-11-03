using FluentAssertions;
using Inno_Shop.CatalogService.Application.Common.Interfaces.Persistence;
using Inno_Shop.CatalogService.Application.Common.Interfaces.Services;
using Inno_Shop.CatalogService.Application.ProductsFunctionality.Commands.CreateProduct;
using Inno_Shop.CatalogService.Application.UnitTests.ProductsFunctionality.Commands.TestUtils;
using Inno_Shop.CatalogService.Application.UnitTests.ProductsFunctionality.TestUtils.Products.Extensions;
using Moq;

namespace Inno_Shop.CatalogService.Application.UnitTests.ProductsFunctionality.Commands.CreateProduct;

public class CreateProductCommandHandlerTests
{
	private readonly CreateProductCommandHandler _handler;
	private readonly Mock<IProductRepository> _mockProductRepository;
	private readonly Mock<IDateTimeProvider> _mockDateTimeProvider;

	public CreateProductCommandHandlerTests()
	{
		_mockProductRepository = new Mock<IProductRepository>();
		var productRepository = _mockProductRepository.Object;

		_mockDateTimeProvider = new Mock<IDateTimeProvider>();
		var dateTimeProvider = _mockDateTimeProvider.Object;

		_handler = new CreateProductCommandHandler(productRepository, dateTimeProvider);
	}

	[Theory]
	[MemberData(nameof(ValidCreateProductCommands))]
	public async Task CreateProductCommandHandler_ShouldReturnCreateProductResult(CreateProductCommand createProductCommand)
	{
		//Act
		var result = await _handler.Handle(createProductCommand, default);

		//Assert
		result.IsError.Should().BeFalse();
		result.Value.Product.ValidateCreatedFrom(createProductCommand);
		_mockProductRepository.Verify(p => p.CreateProduct(result.Value.Product), Times.Once);
	}

	public static IEnumerable<object[]> ValidCreateProductCommands()
	{
		yield return new[] { CreateProductCommandUtils.CreateCommand() };

		yield return new[] { CreateProductCommandUtils.CreateCommand("another product name") };
	}
}