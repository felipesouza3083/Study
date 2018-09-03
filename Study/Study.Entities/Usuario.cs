using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int IdPerfil { get; set; }

        public Perfil Perfil { get; set; }

        public Usuario()
        {

        }

        public Usuario(int idUsuario, string nome, string login, string senha)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Login = login;
            Senha = senha;
        }

        public override string ToString()
        {
            return $"Id do Usuario: {IdUsuario}, Nome: {Nome}";
        }
    }
}
