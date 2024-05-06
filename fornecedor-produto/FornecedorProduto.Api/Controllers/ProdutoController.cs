using FornecedorProduto.Application.Commands.Produto.CreateProduto;
using FornecedorProduto.Application.Commands.Produto.DeleteProduto;
using FornecedorProduto.Application.Commands.Produto.UpdateProduto;
using FornecedorProduto.Application.Queries.Product.GetProductById;
using FornecedorProduto.Application.Queries.Product.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FornecedorProduto.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string query = "")
        {
            var response = await _mediator.Send(new GetProductsQuery(query));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var query = new GetProductByIdQuey(id);

            var response = await _mediator.Send(query);

            return Ok(response);    
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduto([FromBody] CreateProdutoCommand command)
        {
            var id = await _mediator.Send(command);

            if (id == 0) return BadRequest();

            return CreatedAtAction(nameof(Get), new { id }, command);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProdutoCommand command)
        {
            var att = await _mediator.Send(command);

            if (!att) return BadRequest();

            return Created();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var command = new DeleteProdutoCommand(id);

            var delete = await _mediator.Send(command);

            if(!delete) return BadRequest();

            return Ok();
        }
    }
}
