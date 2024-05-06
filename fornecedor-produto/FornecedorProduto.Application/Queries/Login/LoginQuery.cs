using FornecedorProduto.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorProduto.Application.Queries.Login
{
    public class LoginQuery : IRequest<LoginViewModel>
    {
        public LoginQuery(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; private set; }
        public string Senha { get; private set; }

    }
}
