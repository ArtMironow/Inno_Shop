using ErrorOr;
using Inno_Shop.CatalogService.Application.Common.Interfaces.Persistence;
using Inno_Shop.CatalogService.Domain.Common.Errors;
using MediatR;

namespace Inno_Shop.CatalogService.Application.ProductsFunctionality.Queries.GetProduct;

public class GetProductQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductQuery, ErrorOr<GetProductResult>>
{
	private readonly IProductRepository _productRepository = productRepository;
	public async Task<ErrorOr<GetProductResult>> Handle(GetProductQuery query, CancellationToken cancellationToken)
	{
		var product = await _productRepository.GetByProductId(query.Id);

		if (product == null)
		{
			return Errors.Product.NotFound;
		}

		return new GetProductResult(product);
	}
}