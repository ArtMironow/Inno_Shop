using ErrorOr;
using MediatR;

namespace Inno_Shop.IdentityService.Application.UserFunctionality.Commands.DeleteUser;

public record DeleteUserCommand(string Id) : IRequest<ErrorOr<DeleteUserResult>>;