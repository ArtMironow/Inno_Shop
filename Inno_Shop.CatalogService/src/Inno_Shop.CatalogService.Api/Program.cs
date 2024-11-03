using Inno_Shop.CatalogService.Api;
using Inno_Shop.CatalogService.Application;
using Inno_Shop.CatalogService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

{
	builder.Services
		.AddApplication()
		.AddInfrastructure()
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
