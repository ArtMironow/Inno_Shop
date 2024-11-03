using Inno_Shop.IdentityService.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using Inno_Shop.IdentityService.Domain.Common.Errors;
using MediatR;
using Inno_Shop.IdentityService.Application.Authentication.Commands.Register;
using Inno_Shop.IdentityService.Application.Authentication.Common;
using Inno_Shop.IdentityService.Application.Authentication.Queries.Login;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;

namespace Inno_Shop.IdentityService.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController(ISender mediator, IMapper mapper) : ApiController
{
	private readonly ISender _mediator = mediator;
	private readonly IMapper _mapper = mapper;

	[HttpPost("register")]
	public async Task<IActionResult> Register(RegisterRequest request)
	{
		var command = _mapper.Map<RegisterCommand>(request);

		ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

		return authResult.Match(
			authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
			errors => Problem(errors)
		);
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login(LoginRequest request)
	{
		var query = _mapper.Map<LoginQuery>(request);

		var authResult = await _mediator.Send(query);

		if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
		{
			return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
		}

		return authResult.Match(
			authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
			errors => Problem(errors)
		);
	}
}