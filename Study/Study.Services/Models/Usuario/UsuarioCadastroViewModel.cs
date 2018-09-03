using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Study.Services.Models
{
    public class UsuarioCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o nome do usuário.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o login do usuário.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe o perfil do usuário.")]
        public int IdPerfil { get; set; }
    }
}