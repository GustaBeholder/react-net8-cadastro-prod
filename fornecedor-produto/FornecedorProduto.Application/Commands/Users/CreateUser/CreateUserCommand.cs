using MediatR;


namespace FornecedorProduto.Application.Commands.Usuario.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
