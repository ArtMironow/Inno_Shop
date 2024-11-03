namespace Inno_Shop.CatalogService.Contracts.ProductActions.GetAllProducts;

public record GetAllProductsResponse(Guid ProductId, string ProductName, string Description, decimal Price, bool IsAvailable, Guid UserId, DateTime CreatedDate);