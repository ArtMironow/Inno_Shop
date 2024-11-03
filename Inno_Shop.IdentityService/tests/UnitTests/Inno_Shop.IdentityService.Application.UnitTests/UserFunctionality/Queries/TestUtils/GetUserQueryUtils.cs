using Inno_Shop.IdentityService.Application.UserFunctionality.Queries.GetUser;

namespace Inno_Shop.IdentityService.Application.UnitTests.UserFunctionality.Queries.TestUtils;

public class GetUserQueryUtils
{
	public static GetUserQuery CreateQuery(string email) =>
		new(
			email
		);
}