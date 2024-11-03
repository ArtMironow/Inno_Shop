namespace Inno_Shop.IdentityService.Application.Common.Interfaces.Services;

public interface IDateTimeProvider
{
	DateTime UtcNow { get; }
}