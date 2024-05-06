using FornecedorProduto.Application.ViewModels;
using FornecedorProduto.Core.Helpers;
using FornecedorProduto.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorProduto.Application.Queries.Login
{
    internal class LoginQueryHandler : IRequestHandler<LoginQuery, LoginViewModel>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly string secret;

        public LoginQueryHandler(IUsuarioRepository usuarioRepository, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            secret = configuration.GetSection("Key").Value!;
        }

        public async Task<LoginViewModel?> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var senhaCriptografada = Criptografia.CriptografarSenhaSHA256(request.Senha);

            var result = await _usuarioRepository.GetByEmailAndPassword(request.Email, senhaCriptografada);

            if (result == null) return null;

            var loginViewModel = new LoginViewModel()
            {
                Id = result.Id,
                Email = result.Email,
                Nome = result.Nome,
                Token = TokenHelper.GenerateToken(result, secret)
            };

           return loginViewModel;
        }
    }
}
