using ErrorOr;
using Inno_Shop.IdentityService.Domain.Entities;
using MediatR;

namespace Inno_Shop.IdentityService.Application.UserFunctionality.Queries.GetUser;

public record GetUserQuery(string Email) : IRequest<ErrorOr<User>>;