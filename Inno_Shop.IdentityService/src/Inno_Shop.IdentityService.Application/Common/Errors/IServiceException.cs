using System.Net;

namespace Inno_Shop.IdentityService.Application.Common.Errors;

public interface IServiceException
{
	public HttpStatusCode StatusCode { get; }
	public string ErrorMessage { get; }
}