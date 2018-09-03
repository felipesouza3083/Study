    namespace Study.Repository.Migrations
{
    using Study.Entities;
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
        }
    }
}
