using ErrorOr;
using MediatR;

namespace Inno_Shop.IdentityService.Application.UserFunctionality.Commands.UpdateUser;

public record UpdateUserCommand(string Id, string FirstName, string LastName) : IRequest<ErrorOr<UpdateUserResult>>;