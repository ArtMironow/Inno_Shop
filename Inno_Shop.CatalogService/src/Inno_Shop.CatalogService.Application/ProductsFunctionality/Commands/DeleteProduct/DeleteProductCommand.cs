using ErrorOr;
using MediatR;

namespace Inno_Shop.CatalogService.Application.ProductsFunctionality.Commands.DeleteProduct;

public record DeleteProductCommand(string Id, string UserId) : IRequest<ErrorOr<DeleteProductResult>>;