using ErrorOr;
using Inno_Shop.IdentityService.Application.Authentication.Common;
using Inno_Shop.IdentityService.Application.Common.Interfaces.Authentication;
using Inno_Shop.IdentityService.Application.Common.Interfaces.Services;
using Inno_Shop.IdentityService.Application.Services.EmailService;
using Inno_Shop.IdentityService.Domain.Common.Errors;
using Inno_Shop.IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Inno_Shop.IdentityService.Application.Authentication.Commands.Register;

public class RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, UserManager<User> userManager, IEmailSender emailSender)
	: IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
	private readonly UserManager<User> _userManager = userManager;
	private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
	private readonly IEmailSender _emailSender = emailSender;

	public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
	{
		if (await _userManager.FindByEmailAsync(command.Email) is not null)
		{
			return Errors.User.DuplicateEmail;
		}

		var user = new User
		{
			FirstName = command.FirstName,
			LastName = command.LastName,
			UserName = command.Email,
			Email = command.Email
		};

		var result = await _userManager.CreateAsync(user, command.Password);

		if (!result.Succeeded)
		{
			return Errors.User.Unexpected;
		}

		var callback = $"Registered successfully";

		var message = new Message([user.Email!], "Congratulations", callback, null!);

		await _emailSender.SendEmailAsync(message);

		var token = _jwtTokenGenerator.GenerateToken(user);

		return new AuthenticationResult(user, token);
	}
}
