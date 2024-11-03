using Inno_Shop.IdentityService.Domain.Entities;

namespace Inno_Shop.IdentityService.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
	string GenerateToken(User user);
}