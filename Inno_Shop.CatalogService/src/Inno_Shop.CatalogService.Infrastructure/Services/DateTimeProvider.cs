using Inno_Shop.CatalogService.Application.Common.Interfaces.Services;

namespace Inno_Shop.CatalogService.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
	public DateTime UtcNow => DateTime.UtcNow;
}