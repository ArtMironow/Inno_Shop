using Inno_Shop.IdentityService.Api;
using Inno_Shop.IdentityService.Application;
using Inno_Shop.IdentityService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

{
	builder.Services
		.AddApplication(builder.Configuration)
		.AddInfrastructure(builder.Configuration)
		.AddPresentation();
}

var app = builder.Build();

{
	app.UseExceptionHandler("/error");

	app.UseHttpsRedirection();
	app.UseAuthentication();
	app.UseAuthorization();
	app.MapControllers();
	app.Run();
}