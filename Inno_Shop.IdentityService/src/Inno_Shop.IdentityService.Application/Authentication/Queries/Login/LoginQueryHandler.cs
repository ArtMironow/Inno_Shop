using ErrorOr;
using Inno_Shop.IdentityService.Application.Authentication.Common;
using Inno_Shop.IdentityService.Application.Common.Interfaces.Authentication;
using Inno_Shop.IdentityService.Domain.Common.Errors;
using Inno_Shop.IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Inno_Shop.IdentityService.Application.Authentication.Queries.Login;

public class LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, UserManager<User> userManager)
	: IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
	private readonly UserManager<User> _userManager = userManager;
	private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;

	public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
	{
		var user = await _userManager.FindByEmailAsync(query.Email);

		if (user is null)
		{
			return Errors.Authentication.InvalidCredentials;
		}

		if (!await _userManager.CheckPasswordAsync(user, query.Password))
		{
			return new[] { Errors.Authentication.InvalidCredentials };
		}

		var token = _jwtTokenGenerator.GenerateToken(user);

		return new AuthenticationResult(user, token);
	}
}
