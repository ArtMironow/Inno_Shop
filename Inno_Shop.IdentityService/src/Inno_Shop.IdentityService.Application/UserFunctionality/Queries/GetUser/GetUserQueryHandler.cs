using ErrorOr;
using Inno_Shop.IdentityService.Application.UserFunctionality.Queries.GetUser;
using Inno_Shop.IdentityService.Domain.Common.Errors;
using Inno_Shop.IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Inno_Shop.IdentityService.Application.Authentication.Queries.Login;

public class GetUserQueryHandler(UserManager<User> _userManager) : IRequestHandler<GetUserQuery, ErrorOr<User>>
{
	public async Task<ErrorOr<User>> Handle(GetUserQuery query, CancellationToken cancellationToken)
	{
		var user = await _userManager.FindByEmailAsync(query.Email);

		if (user is null)
		{
			return Errors.User.InvalidEmail;
		}

		return user;
	}
}
