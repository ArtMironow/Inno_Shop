using FluentAssertions;
using Inno_Shop.IdentityService.Application.Authentication.Queries.Login;
using Inno_Shop.IdentityService.Application.UnitTests.UserFunctionality.Queries.TestUtils;
using Inno_Shop.IdentityService.Application.UserFunctionality.Queries.GetUser;
using Inno_Shop.IdentityService.Domain.Entities;
using Microsoft.AspNetCore.Identity;
// using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.Options;
using Moq;

namespace Inno_Shop.IdentityService.Application.UnitTests.UserFunctionality.Queries.GetUser;
public class GetUserQueryHandlerTests
{
	private readonly GetUserQueryHandler _handler;
	private readonly Mock<UserManager<User>> _mockUserManager;

	public GetUserQueryHandlerTests()
	{
		_mockUserManager = new Mock<UserManager<User>>();
		var mockUserManager = _mockUserManager.Object;

		_handler = new GetUserQueryHandler(mockUserManager);
	}

	[Theory]
	[MemberData(nameof(ValidGetUserQueries))]
	public async Task GetUserQueryHandler_ShouldReturnUser(GetUserQuery getUserQuery)
	{
		//Act
		var result = await _handler.Handle(getUserQuery, default);

		//Assert
		result.IsError.Should().BeFalse();
		_mockUserManager.Verify(p => p.FindByEmailAsync(getUserQuery.Email), Times.Once);
	}

	public static IEnumerable<object[]> ValidGetUserQueries()
	{
		yield return new[] { GetUserQueryUtils.CreateQuery("one@gmail.com") };

		yield return new[] { GetUserQueryUtils.CreateQuery("two@gmail.com") };
	}

	// private static Mock<UserManager<User>> GetUserManager()
	// {
	// 	return new Mock<UserManager<User>>(
	// 	new Mock<IUserStore<User>>().Object,
	// 	new Mock<IOptions<IdentityOptions>>().Object,
	// 	new Mock<IPasswordHasher<User>>().Object,
	// 	new IUserValidator<User>[0],
	// 	new IPasswordValidator<User>[0],
	// 	new Mock<ILookupNormalizer>().Object,
	// 	new Mock<IdentityErrorDescriber>().Object,
	// 	new Mock<IServiceProvider>().Object,
	// 	new Mock<ILogger<UserManager<User>>>().Object);
	// }
}