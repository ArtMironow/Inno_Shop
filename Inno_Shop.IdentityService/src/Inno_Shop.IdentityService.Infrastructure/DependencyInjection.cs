using System.Text;
using Inno_Shop.IdentityService.Application.Common.Interfaces.Authentication;
using Inno_Shop.IdentityService.Application.Common.Interfaces.Services;
using Inno_Shop.IdentityService.Domain.Entities;
using Inno_Shop.IdentityService.Infrastructure.Authentication;
using Inno_Shop.IdentityService.Infrastructure.Persistence;
using Inno_Shop.IdentityService.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Inno_Shop.IdentityService.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(
		this IServiceCollection services,
		ConfigurationManager configuration)
	{
		// services.AddDbContext<IdentityServiceDbContext>(
		// 	options => options.UseSqlServer("Server=DESKTOP-PRQG9P4\\SQLEXPRESS;Database=InnoShopIdentityServiceDb;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;"));

		services.AddDbContext<IdentityServiceDbContext>(
			options => options.UseSqlServer("Server=db,1433;Database=YourDatabase;User Id=sa;Password=YourPassword123;TrustServerCertificate=True;"));

		services.AddIdentity<User, IdentityRole>(opt =>
		{
			opt.Password.RequiredLength = 7;
			opt.Password.RequireDigit = false;
			opt.User.RequireUniqueEmail = true;
			opt.SignIn.RequireConfirmedEmail = false;
		}).AddEntityFrameworkStores<IdentityServiceDbContext>()
			.AddDefaultTokenProviders();

		services.AddAuth(configuration);

		services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

		return services;
	}

	public static IServiceCollection AddAuth(
		this IServiceCollection services,
		ConfigurationManager configuration)
	{
		var jwtSettings = new JwtSettings();
		configuration.Bind(JwtSettings.SectionName, jwtSettings);

		services.AddSingleton(Options.Create(jwtSettings));
		services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

		services.AddAuthentication(options =>
		{
			options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
		})
			.AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				ValidIssuer = jwtSettings.Issuer,
				ValidAudience = jwtSettings.Audience,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
			});

		return services;
	}
}