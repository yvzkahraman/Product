using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.API.CQRS.CreateProduct;
using Product.API.CQRS.GetProduct;
using Product.API.CQRS.GetProducts;
using Product.API.CQRS.RemoveProduct;
using Product.API.CQRS.UpdateProduct;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await this.mediator.Send(new GetProductsQuery());
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.mediator.Send(new GetProductQuery(id));
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await this.mediator.Send(new RemoveProductCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand product)
        {
            await this.mediator.Send(product);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand product)
        {
            var result = await this.mediator.Send(product);
            return Created("",result);
        }

    }
}
