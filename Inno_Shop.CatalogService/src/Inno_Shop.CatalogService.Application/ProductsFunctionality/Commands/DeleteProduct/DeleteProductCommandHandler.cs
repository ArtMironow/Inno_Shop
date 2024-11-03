using ErrorOr;
using Inno_Shop.CatalogService.Application.Common.Interfaces.Persistence;
using Inno_Shop.CatalogService.Domain.Common.Errors;
using MediatR;

namespace Inno_Shop.CatalogService.Application.ProductsFunctionality.Commands.DeleteProduct;

public class DeleteProductCommandHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductCommand, ErrorOr<DeleteProductResult>>
{
	private readonly IProductRepository _productRepository = productRepository;
	public async Task<ErrorOr<DeleteProductResult>> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
	{
		var product = await _productRepository.GetByProductId(command.Id);

		if (product == null)
		{
			return Errors.Product.NotFound;
		}

		if (product.UserId != Guid.Parse(command.UserId))
		{
			return Errors.User.UserPermissionError;
		}

		await _productRepository.DeleteProduct(product);

		return new DeleteProductResult(command.Id);
	}
}