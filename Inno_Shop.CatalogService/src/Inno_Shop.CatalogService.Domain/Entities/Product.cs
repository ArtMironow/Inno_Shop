namespace Inno_Shop.CatalogService.Domain.Entities;

public class Product
{
	public Guid ProductId { get; set; }
	public string ProductName { get; set; } = null!;
	public string Description { get; set; } = null!;
	public decimal Price { get; set; }
	public bool IsAvailable { get; set; }
	public Guid UserId { get; set; }
	public DateTime CreatedDate { get; set; }
}