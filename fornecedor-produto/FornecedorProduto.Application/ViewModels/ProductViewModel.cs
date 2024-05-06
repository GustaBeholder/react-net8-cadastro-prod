using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorProduto.Application.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string CodigoProduto { get; set; }
        public decimal Preco { get; set; }
        public string CriadoPor { get; set; }
    }
}
