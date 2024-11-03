using ErrorOr;
using Inno_Shop.IdentityService.Application.Authentication.Common;
using MediatR;

namespace Inno_Shop.IdentityService.Application.Authentication.Commands.Register;

public record RegisterCommand(string FirstName, string LastName, string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;