using ErrorOr;
using MediatR;

namespace Inno_Shop.IdentityService.Application.UserFunctionality.Queries.ForgotPassword;

public record ForgotPasswordQuery(string Email) : IRequest<ErrorOr<ForgotPasswordResult>>;