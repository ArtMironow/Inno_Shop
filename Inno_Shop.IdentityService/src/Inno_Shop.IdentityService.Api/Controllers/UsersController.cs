using Inno_Shop.IdentityService.Application.UserFunctionality.Commands.DeleteUser;
using Inno_Shop.IdentityService.Application.UserFunctionality.Commands.UpdateUser;
using Inno_Shop.IdentityService.Application.UserFunctionality.Queries.ForgotPassword;
using Inno_Shop.IdentityService.Application.UserFunctionality.Queries.GetUser;
using Inno_Shop.IdentityService.Contracts.UserActions.DeleteUser;
using Inno_Shop.IdentityService.Contracts.UserActions.ForgotPassword;
using Inno_Shop.IdentityService.Contracts.UserActions.GetUser;
using Inno_Shop.IdentityService.Contracts.UserActions.UpdateUser;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inno_Shop.IdentityService.Api.Controllers;

[Route("users")]
public class UsersController(ISender mediator, IMapper mapper) : ApiController
{
	private readonly ISender _mediator = mediator;
	private readonly IMapper _mapper = mapper;

	[HttpGet("getuser/{email}")]
	public async Task<IActionResult> GetUser(string email)
	{
		var request = new GetUserRequest(email);

		var query = _mapper.Map<GetUserQuery>(request);
		var result = await _mediator.Send(query);

		return result.Match(
			result => Ok(_mapper.Map<GetUserResponse>(result)),
			errors => Problem(errors)
		);
	}

	[HttpDelete("delete/{id}")]
	public async Task<IActionResult> DeleteUser(string id)
	{
		DeleteUserCommand command = new(id);

		var result = await _mediator.Send(command);

		return result.Match(
			result => Ok(_mapper.Map<DeleteUserResponse>(result)),
			errors => Problem(errors)
		);
	}

	[HttpPost("forgotpassword")]
	[AllowAnonymous]
	public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest request)
	{
		var query = _mapper.Map<ForgotPasswordQuery>(request);

		var result = await _mediator.Send(query);

		return result.Match(
			result => Ok(_mapper.Map<ForgotPasswordResponse>(result)),
			errors => Problem(errors)
		);
	}

	[HttpPost("update")]
	public async Task<IActionResult> UpdateUser(UpdateUserRequest request)
	{
		var command = _mapper.Map<UpdateUserCommand>(request);

		var result = await _mediator.Send(command);

		return result.Match(
			result => Ok(_mapper.Map<UpdateUserResponse>(result)),
			errors => Problem(errors)
		);
	}
}