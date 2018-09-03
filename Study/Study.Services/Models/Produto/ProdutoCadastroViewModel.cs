using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Study.Services.Models.Produto
{
    public class ProdutoCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o nome do produto.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a quantidade do produto.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Informe o preço do produto.")]
        public decimal Preco { get; set; }

    }
}