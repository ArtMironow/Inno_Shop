using ErrorOr;
using MediatR;

namespace Inno_Shop.CatalogService.Application.ProductsFunctionality.Queries.GetAllProducts;

public record GetAllProductsQuery(
	string? SearchTerm,
	string? SortColumn,
	string? SortOrder,
	int Page,
	int PageSize) : IRequest<ErrorOr<List<GetAllProductsResult>>>;