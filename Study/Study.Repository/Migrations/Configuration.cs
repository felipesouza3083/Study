namespace Study.Repository.Migrations
{
    using Study.Entities;
    using Study.Repository.Util;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Study.Repository.Context.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Study.Repository.Context.DataContext context)
        {
            context.Perfil.AddOrUpdate(
                new Perfil { IdPerfil = 1, Nome = "Administrador" },
                new Perfil { IdPerfil = 2, Nome = "Operador" }
                );

            context.Usuario.AddOrUpdate(
                new Usuario
                {
                    IdUsuario = 1,
                    Nome = "Feipe Souza",
                    Login = "felipe.souza",
                    Senha = Criptografia.EncriptarSenhaMD5("cd3083"),
                    IdPerfil = 1
                });
        }
    }
}
