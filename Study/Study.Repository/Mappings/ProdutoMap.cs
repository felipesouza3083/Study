using Study.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Repository.Mappings
{
    public class ProdutoMap: EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto");

            HasKey(p => p.IdProduto);

            Property(p => p.IdProduto)
                .HasColumnName("IdProduto")
                .IsRequired();

            Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            Property(p => p.Quantidade)
                .HasColumnName("Quantidade")
                .IsRequired();

            Property(p => p.Preco)
                .HasColumnName("Preco")
                .IsRequired();
        }
    }
}
