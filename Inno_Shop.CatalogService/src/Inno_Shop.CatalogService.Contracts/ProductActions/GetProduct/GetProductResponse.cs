namespace Inno_Shop.CatalogService.Contracts.ProductActions.GetProduct;

public record GetProductResponse(Guid ProductId, string ProductName, string Description, decimal Price, bool IsAvailable, Guid UserId, DateTime CreatedDate);