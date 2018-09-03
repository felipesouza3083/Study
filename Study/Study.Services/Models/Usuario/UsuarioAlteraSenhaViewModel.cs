using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Study.Services.Models.Usuario
{
    public class UsuarioAlteraSenhaViewModel
    {
        [Required(ErrorMessage = "Informe o Id do Usuario")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Informe a nova senha")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Senhas não conferem.")]
        [Required(ErrorMessage = "Informe a confirmação da senha")]
        public string SenhaConfirm { get; set; }
    }
}