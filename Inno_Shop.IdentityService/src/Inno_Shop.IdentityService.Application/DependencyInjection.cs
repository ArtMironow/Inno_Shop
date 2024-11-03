using System.Reflection;
using FluentValidation;
using Inno_Shop.IdentityService.Application.Common.Behaviors;
using Inno_Shop.IdentityService.Application.Common.Interfaces.Services;
using Inno_Shop.IdentityService.Application.Services.EmailService;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inno_Shop.IdentityService.Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services, ConfigurationManager configuration)
	{
		services.AddEmailService(configuration);

		services.AddMediatR(typeof(DependencyInjection).Assembly);

		services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

		return services;
	}

	private static IServiceCollection AddEmailService(this IServiceCollection services, ConfigurationManager configuration)
	{
		var emailConfig = configuration
				 .GetSection("EmailConfiguration")
				 .Get<EmailConfiguration>();

		services.AddSingleton(emailConfig!);
		services.AddScoped<IEmailSender, EmailSender>();

		return services;
	}
}