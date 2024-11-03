using System.Security.Claims;
using Inno_Shop.CatalogService.Application.ProductsFunctionality.Commands.CreateProduct;
using Inno_Shop.CatalogService.Application.ProductsFunctionality.Commands.DeleteProduct;
using Inno_Shop.CatalogService.Application.ProductsFunctionality.Commands.UpdateProduct;
using Inno_Shop.CatalogService.Application.ProductsFunctionality.Queries.GetAllProducts;
using Inno_Shop.CatalogService.Application.ProductsFunctionality.Queries.GetProduct;
using Inno_Shop.CatalogService.Application.ProductsFunctionality.Queries.GetUserProducts;
using Inno_Shop.CatalogService.Contracts.ProductActions.CreateProduct;
using Inno_Shop.CatalogService.Contracts.ProductActions.DeleteProduct;
using Inno_Shop.CatalogService.Contracts.ProductActions.GetAllProducts;
using Inno_Shop.CatalogService.Contracts.ProductActions.GetProduct;
using Inno_Shop.CatalogService.Contracts.ProductActions.GetUserProducts;
using Inno_Shop.CatalogService.Contracts.ProductActions.UpdateProduct;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inno_Shop.CatalogService.Api.Controllers;

[Route("products")]
public class ProductsController(ISender mediator, IMapper mapper) : ApiController
{
	private readonly ISender _mediator = mediator;
	private readonly IMapper _mapper = mapper;

	[HttpPost("create")]
	public async Task<IActionResult> CreateProduct(CreateProductRequest request)
	{
		var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

		var command = new CreateProductCommand(request.ProductName, request.Description, request.Price, request.IsAvailable, userId!);

		var result = await _mediator.Send(command);

		return result.Match(
			result => Ok(_mapper.Map<CreateProductResponse>(result)),
			errors => Problem(errors)
		);
	}

	[HttpDelete("delete/{id}")]
	public async Task<IActionResult> DeleteProduct(string id)
	{
		var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

		var command = new DeleteProductCommand(id, userId!);

		var result = await _mediator.Send(command);

		return result.Match(
			result => Ok(_mapper.Map<DeleteProductResponse>(result)),
			errors => Problem(errors)
		);
	}

	[HttpPost("update")]
	public async Task<IActionResult> UpdateProduct(UpdateProductRequest request)
	{
		var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

		var command = new UpdateProductCommand(request.ProductId, request.ProductName, request.Description, request.Price, request.IsAvailable, userId!);

		var result = await _mediator.Send(command);

		return result.Match(
			result => Ok(_mapper.Map<UpdateProductResponse>(result)),
			errors => Problem(errors)
		);
	}

	[HttpGet("getall")]
	[AllowAnonymous]
	public async Task<IActionResult> GetAllProducts(string? searchTerm, string? sortColumn, string? sortOrder, int page, int pageSize)
	{
		var query = new GetAllProductsQuery(searchTerm, sortColumn, sortOrder, page, pageSize);

		var result = await _mediator.Send(query);

		return result.Match(
			result => Ok(_mapper.Map<List<GetAllProductsResponse>>(result)),
			errors => Problem(errors)
		);
	}

	[HttpGet("getproduct/{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetProduct(string id)
	{
		var query = new GetProductQuery(id);

		var result = await _mediator.Send(query);

		return result.Match(
			result => Ok(_mapper.Map<GetProductResponse>(result)),
			errors => Problem(errors)
		);
	}

	[HttpGet("getuserproducts/{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetProductsByUserId(string id)
	{
		var query = new GetUserProductsQuery(id);

		var result = await _mediator.Send(query);

		return result.Match(
			result => Ok(_mapper.Map<List<GetUserProductsResponse>>(result)),
			errors => Problem(errors)
		);
	}
}