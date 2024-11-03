using ErrorOr;
using MediatR;

namespace Inno_Shop.CatalogService.Application.ProductsFunctionality.Queries.GetProduct;

public record GetProductQuery(string Id) : IRequest<ErrorOr<GetProductResult>>;