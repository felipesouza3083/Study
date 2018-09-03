using Newtonsoft.Json;
using Study.Entities;
using Study.Repository.Contracts;
using Study.Repository.Util;
using Study.Services.Models;
using Study.Services.Models.Usuario;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Study.Services.Controllers
{
    [RoutePrefix("study/usuario")]
    public class UsuarioController : ApiController
    {
        private IUsuarioRepository repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("cadastrarusuario")]
        public HttpResponseMessage Post(UsuarioCadastroViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (repository.hasLogin(model.Login))
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, $"Já existe o login: {model.Login} cadastrado.");
                    }
                    else
                    {
                        Usuario u = new Usuario();

                        u.Nome = model.Nome;
                        u.Login = model.Login;
                        u.Senha = Criptografia.EncriptarSenhaMD5(model.Senha);
                        u.IdPerfil = model.IdPerfil;

                        repository.Insert(u);

                        return Request.CreateResponse(HttpStatusCode.OK, "Usuário cadastrado com sucesso!");
                    }
                }
                else
                {
                    Hashtable erros = new Hashtable();

                    foreach (var m in ModelState)
                    {
                        if (m.Value.Errors.Count > 0)
                        {
                            erros[m.Key] = m.Value.Errors.Select(e => e.ErrorMessage);
                        }
                    }

                    return Request.CreateResponse(HttpStatusCode.BadRequest, erros);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("obterdados")]
        [Authorize]
        public HttpResponseMessage GetData()
        {
            try
            {
                Usuario u = JsonConvert.DeserializeObject<Usuario>(User.Identity.Name);

                UsuarioAutenticadoViewModel model = new UsuarioAutenticadoViewModel();

                model.IdUsuario = u.IdUsuario;
                model.Nome = u.Nome;
                model.Login = u.Login;

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("atualizarsenha")]
        [Authorize]
        public HttpResponseMessage Put(UsuarioAlteraSenhaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.TrocaSenha(model.IdUsuario, Criptografia.EncriptarSenhaMD5(model.Senha));
                    
                    return Request.CreateResponse(HttpStatusCode.OK, "Senha alterada com sucesso!");
                }
                else
                {
                    Hashtable erros = new Hashtable();

                    foreach (var m in ModelState)
                    {
                        if (m.Value.Errors.Count > 0)
                        {
                            erros[m.Key] = m.Value.Errors.Select(e => e.ErrorMessage);
                        }
                    }

                    return Request.CreateResponse(HttpStatusCode.BadRequest, erros);
                }
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
