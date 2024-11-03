using ErrorOr;
using Inno_Shop.CatalogService.Application.Common.Interfaces.Persistence;
using Inno_Shop.CatalogService.Domain.Common.Errors;
using MediatR;

namespace Inno_Shop.CatalogService.Application.ProductsFunctionality.Queries.GetUserProducts;

public class GetUserProductsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetUserProductsQuery, ErrorOr<List<GetUserProductsResult>>>
{
	private readonly IProductRepository _productRepository = productRepository;
	public async Task<ErrorOr<List<GetUserProductsResult>>> Handle(GetUserProductsQuery query, CancellationToken cancellationToken)
	{
		var products = await _productRepository.GetProductsByUserId(Guid.Parse(query.UserId));

		if (products == null)
		{
			return Errors.Product.NotFound;
		}

		var result = products.Select(p => new GetUserProductsResult(p)).ToList();

		return result;
	}
}