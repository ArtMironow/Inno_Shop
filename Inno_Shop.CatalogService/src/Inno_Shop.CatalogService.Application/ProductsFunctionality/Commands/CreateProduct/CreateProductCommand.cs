using ErrorOr;
using MediatR;

namespace Inno_Shop.CatalogService.Application.ProductsFunctionality.Commands.CreateProduct;

public record CreateProductCommand(string ProductName, string Description, decimal Price, bool IsAvailable, string UserId) : IRequest<ErrorOr<CreateProductResult>>;