using System.Linq.Expressions;
using ErrorOr;
using Inno_Shop.CatalogService.Application.Common.Interfaces.Persistence;
using Inno_Shop.CatalogService.Domain.Common.Errors;
using Inno_Shop.CatalogService.Domain.Entities;
using MediatR;

namespace Inno_Shop.CatalogService.Application.ProductsFunctionality.Queries.GetAllProducts;

public class GetAllProductsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, ErrorOr<List<GetAllProductsResult>>>
{
	private readonly IProductRepository _productRepository = productRepository;
	public async Task<ErrorOr<List<GetAllProductsResult>>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
	{
		var productsQuery = _productRepository.GetAllProducts();

		if (productsQuery == null)
		{
			return Errors.Product.NotFound;
		}

		if (!string.IsNullOrWhiteSpace(query.SearchTerm))
		{
			productsQuery = productsQuery.Where(p => p.ProductName.Contains(query.SearchTerm) || p.Description.Contains(query.SearchTerm));
		}

		if (query.SortOrder?.ToLower() == "desc")
		{
			productsQuery = productsQuery.OrderByDescending(GetSortProperty(query));
		}
		else
		{
			productsQuery = productsQuery.OrderBy(GetSortProperty(query));
		}

		var result = productsQuery
			.Skip((query.Page - 1) * query.PageSize)
			.Take(query.PageSize)
			.Select(p => new GetAllProductsResult(p))
			.ToList();

		await Task.CompletedTask;
		return result;
	}

	private static Expression<Func<Product, object>> GetSortProperty(GetAllProductsQuery query)
	{
		return query.SortColumn?.ToLower() switch
		{
			"description" => product => product.Description,
			"price" => product => product.Price,
			_ => product => product.ProductName,
		};
	}
}