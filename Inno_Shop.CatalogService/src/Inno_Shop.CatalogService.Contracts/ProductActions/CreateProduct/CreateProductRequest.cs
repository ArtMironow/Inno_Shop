namespace Inno_Shop.CatalogService.Contracts.ProductActions.CreateProduct;

public record CreateProductRequest(string ProductName, string Description, decimal Price, bool IsAvailable);