using ErrorOr;

namespace Inno_Shop.IdentityService.Domain.Common.Errors;

public static partial class Errors
{
	public static class Authentication
	{
		public static Error InvalidCredentials => Error.Validation(code: "Auth.InvalidCred", description: "Invalid credentials");
		public static Error InvalidAuthentication => Error.Validation(code: "Auth.InvalidAuth", description: "Invalid authentication");
	}
}