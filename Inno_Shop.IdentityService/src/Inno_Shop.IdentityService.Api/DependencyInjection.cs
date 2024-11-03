using Inno_Shop.IdentityService.Api.Common.Errors;
using Inno_Shop.IdentityService.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Inno_Shop.IdentityService.Api;

public static class DependencyInjection
{
	public static IServiceCollection AddPresentation(this IServiceCollection services)
	{
		services.AddMappings();

		services.AddControllers();

		services.AddSingleton<ProblemDetailsFactory, InnoShopProblemDetailsFactory>();

		return services;
	}
}