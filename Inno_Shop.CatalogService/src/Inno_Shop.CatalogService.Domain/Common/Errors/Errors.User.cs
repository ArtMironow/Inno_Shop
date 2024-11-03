using ErrorOr;

namespace Inno_Shop.CatalogService.Domain.Common.Errors;

public static partial class Errors
{
	public static class User
	{
		public static Error UserPermissionError => Error.Validation(code: "Product.UserPermissionError", description: "User can only delete his own products. Permission denied");
	}
}