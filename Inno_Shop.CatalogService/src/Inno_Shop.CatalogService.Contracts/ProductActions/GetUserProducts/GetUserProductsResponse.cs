namespace Inno_Shop.CatalogService.Contracts.ProductActions.GetUserProducts;

public record GetUserProductsResponse(Guid ProductId, string ProductName, string Description, decimal Price, bool IsAvailable, Guid UserId, DateTime CreatedDate);