using System.Net;

namespace Inno_Shop.CatalogService.Application.Common.Errors;

public interface IServiceException
{
	public HttpStatusCode StatusCode { get; }
	public string ErrorMessage { get; }
}