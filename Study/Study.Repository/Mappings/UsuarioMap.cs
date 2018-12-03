using Study.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Repository.Mappings
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");

            HasKey(u => u.IdUsuario);

            Property(u => u.IdUsuario)
                .HasColumnName("IdUsuario")
                .IsRequired();

            Property(u => u.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            Property(u => u.Login)
                .HasColumnName("Login")
                .HasMaxLength(150)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("ix_Login") { IsUnique = true}));

            Property(u => u.Senha)
                .HasColumnName("Senha")
                .IsRequired();

            Property(u => u.IdPerfil)
                .HasColumnName("IdPerfil")
                .IsRequired();


            HasRequired(u => u.Perfil).WithMany(p => p.Usuarios).HasForeignKey(u => u.IdPerfil).WillCascadeOnDelete(false);
                
        }
    }
}
