using ErrorOr;
using Inno_Shop.CatalogService.Application.Common.Interfaces.Persistence;
using Inno_Shop.CatalogService.Domain.Common.Errors;
using MediatR;

namespace Inno_Shop.CatalogService.Application.ProductsFunctionality.Commands.UpdateProduct;

public class UpdateProductCommandHandler(IProductRepository productRepository) : IRequestHandler<UpdateProductCommand, ErrorOr<UpdateProductResult>>
{
	private readonly IProductRepository _productRepository = productRepository;
	public async Task<ErrorOr<UpdateProductResult>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
	{
		var product = await _productRepository.GetByProductId(command.ProductId);

		if (product == null)
		{
			return Errors.Product.NotFound;
		}

		if (product.UserId != Guid.Parse(command.UserId))
		{
			return Errors.User.UserPermissionError;
		}

		product.ProductName = command.ProductName;
		product.Description = command.Description;
		product.Price = command.Price;
		product.IsAvailable = command.IsAvailable;

		await _productRepository.UpdateProduct(product);

		return new UpdateProductResult(product);
	}
}