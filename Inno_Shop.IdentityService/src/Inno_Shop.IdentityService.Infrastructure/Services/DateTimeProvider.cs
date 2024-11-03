using Inno_Shop.IdentityService.Application.Common.Interfaces.Services;

namespace Inno_Shop.IdentityService.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
	public DateTime UtcNow => DateTime.UtcNow;
}
