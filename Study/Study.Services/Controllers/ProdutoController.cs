using Study.Entities;
using Study.Repository.Contracts;
using Study.Services.Models.Produto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Study.Services.Controllers
{
    [Authorize]
    [RoutePrefix("study/produto")]
    public class ProdutoController : ApiController
    {
        private IProdutoRepository repository;

        public ProdutoController(IProdutoRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("cadastrarproduto")]
        public HttpResponseMessage Post(ProdutoCadastroViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Produto p = new Produto();

                    p.Nome = model.Nome;
                    p.Quantidade = model.Quantidade;
                    p.Preco = model.Quantidade;

                    repository.Insert(p);

                    return Request.CreateResponse(HttpStatusCode.OK, "Produto cadastrado com sucesso.");
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

        [HttpPut]
        [AllowAnonymous]
        [Route("atualizarproduto")]
        public HttpResponseMessage Put(ProdutoAtualizaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Produto p = new Produto();

                    p.IdProduto = model.IdProduto;
                    p.Nome = model.Nome;
                    p.Quantidade = model.Quantidade;
                    p.Preco = model.Quantidade;

                    repository.Update(p);

                    return Request.CreateResponse(HttpStatusCode.OK, "Produto atualizado com sucesso.");
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

        [HttpDelete]
        [AllowAnonymous]
        [Route("excluirproduto")]
        public HttpResponseMessage Delete(int idProduto)
        {
            try
            {
                var p = repository.FindById(idProduto);

                repository.Delete(p);

                return Request.CreateResponse(HttpStatusCode.OK, "Produto excluído com sucesso.");
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("listartodosprodutos")]
        public HttpResponseMessage Get()
        {
            try
            {
                List<ProdutoConsultaViewModel> lista = new List<ProdutoConsultaViewModel>();

                foreach (Produto p in repository.FindAll())
                {
                    ProdutoConsultaViewModel model = new ProdutoConsultaViewModel();

                    model.IdProduto = p.IdProduto;
                    model.Nome = p.Nome;
                    model.Quantidade = p.Quantidade;
                    model.Preco = p.Preco;

                    lista.Add(model);
                }
                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("listarprodutoporid")]
        public HttpResponseMessage GetById(int idProduto)
        {
            try
            {
                var p = repository.FindById(idProduto);

                ProdutoConsultaViewModel model = null;
                if(p != null)
                {
                    model.IdProduto = p.IdProduto;
                    model.Nome = p.Nome;
                    model.Preco = p.Preco;
                    model.Quantidade = p.Quantidade;
                }

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
