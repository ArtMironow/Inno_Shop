using System.Reflection;
using FluentValidation;
using Inno_Shop.CatalogService.Application.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Inno_Shop.CatalogService.Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{

		services.AddMediatR(typeof(DependencyInjection).Assembly);

		services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

		return services;
	}
}