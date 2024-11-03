namespace Inno_Shop.CatalogService.Application.Common.Interfaces.Services;

public interface IDateTimeProvider
{
	DateTime UtcNow { get; }
}