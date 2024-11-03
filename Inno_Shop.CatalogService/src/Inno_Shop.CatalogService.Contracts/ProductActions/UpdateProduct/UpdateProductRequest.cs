namespace Inno_Shop.CatalogService.Contracts.ProductActions.UpdateProduct;

public record UpdateProductRequest(string ProductId, string ProductName, string Description, decimal Price, bool IsAvailable);