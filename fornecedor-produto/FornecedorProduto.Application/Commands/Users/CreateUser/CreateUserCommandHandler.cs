using FornecedorProduto.Application.Commands.Usuario.CreateUser;

using FornecedorProduto.Core.Interfaces.Repositories;
using FornecedorProduto.Core.Entities;
using MediatR;
using FornecedorProduto.Core.Helpers;


namespace FornecedorProduto.Application.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public CreateUserCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var senhaCriptografada = Criptografia.CriptografarSenhaSHA256(request.Senha);

            var usuario = new User(request.Nome, request.Email, senhaCriptografada);

            var id = await _usuarioRepository.CreateUser(usuario);

            return id;
        }
    }
}
