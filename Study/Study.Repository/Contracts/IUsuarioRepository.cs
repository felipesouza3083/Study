using Study.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Repository.Contracts
{
    public interface IUsuarioRepository: IBaseRepository<Usuario>
    {
        Usuario Find(string login, string senha);

        bool hasLogin(string login);

        void TrocaSenha(int idUsuario, string novaSenha);
    }
}
