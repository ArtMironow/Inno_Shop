namespace Inno_Shop.CatalogService.Contracts.ProductActions.UpdateProduct;

public record UpdateProductResponse(Guid ProductId, string ProductName, string Description, decimal Price, bool IsAvailable, Guid UserId, DateTime CreatedDate);