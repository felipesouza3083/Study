using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Study.Entities;
using Study.Repository.Repositories;
using Study.Repository.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Study.Services.Providers
{
    public class ApplicationAuthProvider: OAuthAuthorizationServerProvider
    {

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            UsuarioRepository rep = new UsuarioRepository();

            Usuario u = rep.Find(context.UserName, Criptografia.EncriptarSenhaMD5(context.Password));

            if(u != null)
            {
                Claim c = new Claim(ClaimTypes.Name, JsonConvert.SerializeObject(u));

                Claim[] autorizacoes = new Claim[] { c };
                ClaimsIdentity id = new ClaimsIdentity(autorizacoes, OAuthDefaults.AuthenticationType);

                context.Validated(id);
            }

            return Task.FromResult<object>(null);
        }


    }
}