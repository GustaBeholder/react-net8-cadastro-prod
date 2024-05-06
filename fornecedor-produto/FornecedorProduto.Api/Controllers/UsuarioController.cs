
using FornecedorProduto.Application.Commands.Usuario.CreateUser;
using FornecedorProduto.Application.ViewModels;
using FornecedorProduto.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FornecedorProduto.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { id }, command);
        }


    }
}