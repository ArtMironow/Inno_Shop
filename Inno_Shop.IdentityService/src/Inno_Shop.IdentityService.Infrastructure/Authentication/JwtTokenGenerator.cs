using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Inno_Shop.IdentityService.Application.Common.Interfaces.Authentication;
using Inno_Shop.IdentityService.Application.Common.Interfaces.Services;
using Inno_Shop.IdentityService.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Inno_Shop.IdentityService.Infrastructure.Authentication;

public class JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions) : IJwtTokenGenerator
{
	private readonly JwtSettings _jwtSettings = jwtOptions.Value;
	private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

	public string GenerateToken(User user)
	{
		var signingCredentials = new SigningCredentials(
			new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
				SecurityAlgorithms.HmacSha256);

		var claims = new[]
		{
			new Claim(JwtRegisteredClaimNames.Sub, user.Id),
			new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
			new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
		};

		var securityToken = new JwtSecurityToken(
			issuer: _jwtSettings.Issuer,
			audience: _jwtSettings.Audience,
			expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
			claims: claims,
			signingCredentials: signingCredentials);

		return new JwtSecurityTokenHandler().WriteToken(securityToken);
	}
}