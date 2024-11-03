using ErrorOr;
using Inno_Shop.IdentityService.Application.Common.Interfaces.Services;
using Inno_Shop.IdentityService.Application.Features;
using Inno_Shop.IdentityService.Application.Services.EmailService;
using Inno_Shop.IdentityService.Application.UserFunctionality.Queries.ForgotPassword;
using Inno_Shop.IdentityService.Domain.Common.Errors;
using Inno_Shop.IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Inno_Shop.IdentityService.Application.UserFunctionality.Commands.DeleteUser;

public class ForgotPasswordQueryHandler(UserManager<User> userManager, IEmailSender emailSender)
	: IRequestHandler<ForgotPasswordQuery, ErrorOr<ForgotPasswordResult>>
{
	private readonly UserManager<User> _userManager = userManager;
	private readonly IEmailSender _emailSender = emailSender;

	public async Task<ErrorOr<ForgotPasswordResult>> Handle(ForgotPasswordQuery query, CancellationToken cancellationToken)
	{
		var user = await _userManager.FindByEmailAsync(query.Email);

		if (user == null)
		{
			return Errors.Authentication.InvalidAuthentication;
		}

		var token = await _userManager.GeneratePasswordResetTokenAsync(user);

		var newPassword = PasswordGenerator.GeneratePassword();

		var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

		if (!result.Succeeded)
		{
			return Errors.User.Unexpected;
		}

		var callback = $"New password: {newPassword}";

		var message = new Message([user.Email!], "New Password", callback, null!);

		await _emailSender.SendEmailAsync(message);

		return new ForgotPasswordResult(query.Email);
	}
}