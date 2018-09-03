using Study.Entities;
using Study.Repository.Context;
using Study.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Repository.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public Usuario Find(string login, string senha)
        {
            using (DataContext d = new DataContext())
            {
                return d.Usuario.FirstOrDefault(u => u.Login.Equals(login)
                                                  && u.Senha.Equals(senha));
            }
        }

        public bool hasLogin(string login)
        {
            using (DataContext d = new DataContext())
            {
                return d.Usuario.Count(u => u.Login.Equals(login)) > 0;
            }
        }

        public void TrocaSenha(int idUsuario, string novaSenha)
        {
            var u = new Usuario() { IdUsuario = idUsuario, Senha = novaSenha };

            using (DataContext d = new DataContext())
            {
                d.Usuario.Attach(u);
                d.Entry(u).Property(us => us.Senha).IsModified = true;
                d.SaveChanges();
            }
        }
    }
}
