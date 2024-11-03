using FluentValidation;

namespace Inno_Shop.CatalogService.Application.ProductsFunctionality.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
	public UpdateProductCommandValidator()
	{
		RuleFor(x => x.ProductName).NotEmpty().MaximumLength(50);
		RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
		RuleFor(x => x.Price).NotEmpty().PrecisionScale(18, 4, true);
	}
}