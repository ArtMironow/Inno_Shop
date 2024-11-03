namespace Inno_Shop.CatalogService.Contracts.ProductActions.CreateProduct;

public record CreateProductResponse(Guid ProductId, string ProductName, string Description, decimal Price, bool IsAvailable, Guid UserId, DateTime CreatedDate);