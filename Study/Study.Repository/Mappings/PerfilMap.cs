using Study.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Repository.Mappings
{
    public class PerfilMap: EntityTypeConfiguration<Perfil>
    {
        public PerfilMap()
        {
            ToTable("Perfil");

            HasKey(p => p.IdPerfil);

            Property(p => p.IdPerfil)
                .HasColumnName("IdPerfil")
                .IsRequired();

            Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
