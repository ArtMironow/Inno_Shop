using ErrorOr;
using MediatR;

namespace Inno_Shop.CatalogService.Application.ProductsFunctionality.Commands.UpdateProduct;

public record UpdateProductCommand(string ProductId, string ProductName, string Description, decimal Price, bool IsAvailable, string UserId) : IRequest<ErrorOr<UpdateProductResult>>;