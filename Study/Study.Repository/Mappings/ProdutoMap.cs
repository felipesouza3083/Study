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
            ToTable("TB_PRODUTO");

            HasKey(p => p.IdProduto);

            Property(p => p.IdProduto)
                .HasColumnName("ID_PRODUTO")
                .IsRequired();

            Property(p => p.Nome)
                .HasColumnName("NM_PRODUTO")
                .HasMaxLength(150)
                .IsRequired();

            Property(p => p.Quantidade)
                .HasColumnName("QTD_PRODUTO")
                .IsRequired();

            Property(p => p.Preco)
                .HasColumnName("PRECO_PRODUTO")
                .IsRequired();
        }
    }
}
