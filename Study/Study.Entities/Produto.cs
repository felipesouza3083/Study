using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Entities
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }

        public Produto()
        {

        }

        public Produto(int idProduto, string nome, int quantidade, decimal preco)
        {
            IdProduto = idProduto;
            Nome = nome;
            Quantidade = quantidade;
            Preco = preco;
        }

        public override string ToString()
        {
            return $"Id do Produto: {IdProduto}, Nome:{Nome}, Qtd:{Quantidade}, Preco:{Preco}";
        }
    }
}
