using Inno_Shop.CatalogService.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Inno_Shop.CatalogService.Api.Controllers;

public class ErrorsController : ApiController
{
	[Route("/error")]
	public IActionResult Error()
	{
		Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

		var (statusCode, message) = exception switch
		{
			IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
			_ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred"),
		};

		return Problem(statusCode: statusCode, title: message);
	}
}