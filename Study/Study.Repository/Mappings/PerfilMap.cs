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
            ToTable("TB_PERFIL");

            HasKey(p => p.IdPerfil);

            Property(p => p.IdPerfil)
                .HasColumnName("ID_PERFIL")
                .IsRequired();

            Property(p => p.Nome)
                .HasColumnName("DC_PERFIL")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
