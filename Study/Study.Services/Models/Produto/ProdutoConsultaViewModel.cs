using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Study.Services.Models.Produto
{
    public class ProdutoConsultaViewModel
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }
}