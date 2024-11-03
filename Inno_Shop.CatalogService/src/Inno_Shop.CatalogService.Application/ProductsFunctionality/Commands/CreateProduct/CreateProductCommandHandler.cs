using ErrorOr;
using Inno_Shop.CatalogService.Application.Common.Interfaces.Persistence;
using Inno_Shop.CatalogService.Application.Common.Interfaces.Services;
using Inno_Shop.CatalogService.Domain.Common.Errors;
using Inno_Shop.CatalogService.Domain.Entities;
using MediatR;

namespace Inno_Shop.CatalogService.Application.ProductsFunctionality.Commands.CreateProduct;

public class CreateProductCommandHandler(IProductRepository productRepository, IDateTimeProvider dateTimeProvider) : IRequestHandler<CreateProductCommand, ErrorOr<CreateProductResult>>
{
	private readonly IProductRepository _productRepository = productRepository;
	private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
	public async Task<ErrorOr<CreateProductResult>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
	{
		var product = new Product
		{
			ProductId = Guid.NewGuid(),
			ProductName = command.ProductName,
			Description = command.Description,
			Price = command.Price,
			IsAvailable = command.IsAvailable,
			UserId = Guid.Parse(command.UserId),
			CreatedDate = _dateTimeProvider.UtcNow,
		};

		try
		{
			await _productRepository.CreateProduct(product);
		}
		catch
		{
			return Errors.Product.ErrorException;
		}

		return new CreateProductResult(product);
	}
}