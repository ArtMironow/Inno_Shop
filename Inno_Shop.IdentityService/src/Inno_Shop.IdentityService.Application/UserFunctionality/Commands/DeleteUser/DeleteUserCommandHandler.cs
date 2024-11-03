using ErrorOr;
using Inno_Shop.IdentityService.Domain.Common.Errors;
using Inno_Shop.IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Inno_Shop.IdentityService.Application.UserFunctionality.Commands.DeleteUser;

public class DeleteUserCommandHandler(UserManager<User> _userManager) : IRequestHandler<DeleteUserCommand, ErrorOr<DeleteUserResult>>
{
	public async Task<ErrorOr<DeleteUserResult>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
	{
		var user = await _userManager.FindByIdAsync(command.Id);

		if (user is null)
		{
			return Errors.User.InvalidId;
		}

		var result = await _userManager.DeleteAsync(user);

		if (!result.Succeeded)
		{
			return Errors.User.Unexpected;
		}

		return new DeleteUserResult(command.Id);
	}
}