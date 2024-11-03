using FluentValidation;

namespace Inno_Shop.CatalogService.Application.ProductsFunctionality.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
	public CreateProductCommandValidator()
	{
		RuleFor(x => x.ProductName).NotEmpty().MaximumLength(50);
		RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
		RuleFor(x => x.Price).NotEmpty().PrecisionScale(18, 4, true);
	}
}