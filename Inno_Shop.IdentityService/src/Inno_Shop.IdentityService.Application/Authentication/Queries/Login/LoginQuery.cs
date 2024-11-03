using ErrorOr;
using Inno_Shop.IdentityService.Application.Authentication.Common;
using MediatR;

namespace Inno_Shop.IdentityService.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;