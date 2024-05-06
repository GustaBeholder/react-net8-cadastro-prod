using FornecedorProduto.Application.Queries.Login;
using FornecedorProduto.Core.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FornecedorProduto.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginQuery user)
        {
            var result = await _mediator.Send(user);

            if(result == null) return NotFound();

            return Ok(result);
        }

    }
}
