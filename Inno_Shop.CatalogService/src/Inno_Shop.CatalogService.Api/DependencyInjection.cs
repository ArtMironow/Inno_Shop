using Inno_Shop.CatalogService.Api.Common.Errors;
using Inno_Shop.CatalogService.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Inno_Shop.CatalogService.Api;

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