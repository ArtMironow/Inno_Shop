using System.Text;
using Inno_Shop.CatalogService.Application.Common.Interfaces.Persistence;
using Inno_Shop.CatalogService.Application.Common.Interfaces.Services;
using Inno_Shop.CatalogService.Infrastructure.Persistence;
using Inno_Shop.CatalogService.Infrastructure.Persistence.Repositories;
using Inno_Shop.CatalogService.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Inno_Shop.CatalogService.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		// services.AddDbContext<CatalogServiceDbContext>(
		// 	options => options.UseSqlServer("Server=DESKTOP-PRQG9P4\\SQLEXPRESS;Database=InnoShopCatalogServiceDb;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;"));

		//Server=db,1433;Database=YourDatabase;User Id=sa;Password=YourPassword123;TrustServerCertificate=True;
		services.AddDbContext<CatalogServiceDbContext>(
			options => options.UseSqlServer("Server=catalog-db,1433;Database=YourDatabase;User Id=sa;Password=YourPassword123;TrustServerCertificate=True;"));

		services.AddScoped<IProductRepository, ProductRepository>();

		services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

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
				ValidIssuer = "Inno_Shop.IdentityService",
				ValidAudience = "Inno_Shop.IdentityService",
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secret-artems-mironau-security-key123456789"))
			});

		return services;
	}
}