using ECommerceApp.Application.Features.Categories.Queries;
using ECommerceApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {


        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            GetAllCategoriesQuery query = new GetAllCategoriesQuery();
            var result = await Mediator.Send(query);
            return Ok(result);

        }



    }
}
