using ErrorOr;
using MediatR;

namespace Inno_Shop.CatalogService.Application.ProductsFunctionality.Queries.GetUserProducts;

public record GetUserProductsQuery(string UserId) : IRequest<ErrorOr<List<GetUserProductsResult>>>;