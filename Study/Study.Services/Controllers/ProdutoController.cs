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

        [HttpGet]
        [Route("listartodosprodutos")]
        public HttpResponseMessage ListarTodos()
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
    }
}
