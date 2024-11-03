using ErrorOr;

namespace Inno_Shop.IdentityService.Domain.Common.Errors;

public static partial class Errors
{
	public static class User
	{
		public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail", description: "Email is already in use");
		public static Error Unexpected => Error.Conflict(code: "User.UnexpectedException", description: "Something unexpected occurred");
		public static Error InvalidEmail => Error.Conflict(code: "User.InvalidEmail", description: "Email is invalid");
		public static Error InvalidId => Error.Conflict(code: "User.InvalidId", description: "User id is invalid");
		public static Error UpdateError => Error.Conflict(code: "User.UpdateError", description: "Update user error");
	}
}