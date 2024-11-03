using ErrorOr;

namespace Inno_Shop.CatalogService.Domain.Common.Errors;

public static partial class Errors
{
	public static class Product
	{
		public static Error ErrorException => Error.Validation(code: "Product.ErrorException", description: "Some exception occured");
		public static Error NotFound => Error.Validation(code: "Product.NotFound", description: "Product was not found");
	}
}