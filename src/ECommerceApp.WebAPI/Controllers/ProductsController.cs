using ECommerceApp.Application.Features.Products.Commands.Create;
using ECommerceApp.Application.Features.Products.Dtos;
using ECommerceApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : BaseController
{

    //[HttpGet]
    //public async Task<IActionResult> Get()
    //{
    //    var result = await productRepository.GetAsync();
    //    return Ok(result);
    //}

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProductCommand createProductCommand)
    {
        CreateProductDto createdProductDto = await Mediator.Send(createProductCommand);
        return Ok(createdProductDto);
    }
}
