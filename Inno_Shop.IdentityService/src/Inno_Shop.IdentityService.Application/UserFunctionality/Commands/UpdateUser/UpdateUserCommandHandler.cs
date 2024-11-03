using ErrorOr;
using Inno_Shop.IdentityService.Application.Common.Interfaces.Authentication;
using Inno_Shop.IdentityService.Domain.Common.Errors;
using Inno_Shop.IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Inno_Shop.IdentityService.Application.UserFunctionality.Commands.UpdateUser;

public class UpdateUserCommandHandler(UserManager<User> userManager, IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<UpdateUserCommand, ErrorOr<UpdateUserResult>>
{
	private readonly UserManager<User> _userManager = userManager;
	private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
	public async Task<ErrorOr<UpdateUserResult>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
	{
		var user = await _userManager.FindByIdAsync(command.Id);

		if (user is null)
		{
			return Errors.User.InvalidId;
		}

		user.FirstName = command.FirstName;
		user.LastName = command.LastName;

		var result = await _userManager.UpdateAsync(user);

		if (!result.Succeeded)
		{
			return Errors.User.UpdateError;
		}

		var token = _jwtTokenGenerator.GenerateToken(user);

		return new UpdateUserResult(user.Id, user.FirstName, user.LastName, token);
	}
}