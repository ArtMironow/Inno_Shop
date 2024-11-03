using Inno_Shop.CatalogService.Application.ProductsFunctionality.Commands.CreateProduct;
using Inno_Shop.CatalogService.Application.ProductsFunctionality.Commands.UpdateProduct;
using Inno_Shop.CatalogService.Application.ProductsFunctionality.Queries.GetAllProducts;
using Inno_Shop.CatalogService.Application.ProductsFunctionality.Queries.GetProduct;
using Inno_Shop.CatalogService.Application.ProductsFunctionality.Queries.GetUserProducts;
using Inno_Shop.CatalogService.Contracts.ProductActions.CreateProduct;
using Inno_Shop.CatalogService.Contracts.ProductActions.GetAllProducts;
using Inno_Shop.CatalogService.Contracts.ProductActions.GetProduct;
using Inno_Shop.CatalogService.Contracts.ProductActions.GetUserProducts;
using Inno_Shop.CatalogService.Contracts.ProductActions.UpdateProduct;
using Mapster;

namespace Inno_Shop.CatalogService.Api.Common.Mapping;

public class ProductMappingConfig : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<CreateProductResult, CreateProductResponse>()
			.Map(dest => dest, src => src.Product);

		config.NewConfig<UpdateProductResult, UpdateProductResponse>()
			.Map(dest => dest, src => src.Product);

		config.NewConfig<GetAllProductsResult, GetAllProductsResponse>()
			.Map(dest => dest, src => src.Product);

		config.NewConfig<GetProductResult, GetProductResponse>()
		.Map(dest => dest, src => src.Product);

		config.NewConfig<GetUserProductsResult, GetUserProductsResponse>()
		.Map(dest => dest, src => src.Product);
	}
}