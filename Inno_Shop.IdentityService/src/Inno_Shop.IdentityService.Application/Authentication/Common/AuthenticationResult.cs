using Inno_Shop.IdentityService.Domain.Entities;

namespace Inno_Shop.IdentityService.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);