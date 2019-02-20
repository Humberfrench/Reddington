using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rendimento.AutenticacaoMultifatorial.Aplicacao.Interfaces;
using Rendimento.AutenticacaoMultifatorial.Aplicacao.ViewModels;
using Rendimento.AutenticacaoMultifatorial.Infra.Core;
using Rendimento.AutenticacaoMultifatorial.Infra.CrossCutting.Core;

namespace Rendimento.AutenticacaoMultifatorial.Gerenciador.Controllers
{
    [RoutePrefix("Perfil")]
    public class PerfilController : BaseController
    {
        #region Vars
        
        private readonly IPerfilAppService perfilAppService;

        #endregion

        #region Ctor

        public PerfilController(IPerfilAppService perfilAppService)
        {
            this.perfilAppService = perfilAppService;
        }

        #endregion

        #region Public Methods
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Perfil",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Perfil", ActionName = "Index", ControllerName = "Perfil"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Perfil"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaPerfis = perfilAppService.ObterTodos();
            return View(listaPerfis);
        }

        [HttpGet]
        [Route("Filtrar/{status?}/{nome?}")]
        public ActionResult Filtrar(int status = -1, string nome = "")
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Perfil",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Perfil", ActionName = "Index", ControllerName = "Perfil"},
                 new BreadCrumb {LinkText = "Filtro", ActionName = "Filtro", ControllerName = "Perfil"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion
            var listaPerfis = perfilAppService.Filtrar(status, nome);

            return View("Index", listaPerfis);
        }

        public ActionResult Edit(int id)
        {
            var retorno = perfilAppService.ObterPorId(id);

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public ActionResult Gravar(PerfilViewModel perfil)
        {
            var gravarResult = perfilAppService.Gravar(perfil);
            object retorno;
            if (gravarResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Registro Gravado com Sucesso",
                    Erro = false
                };
            }
            else
            {
                retorno = new
                {
                    Mensagem = RenderizeErros(gravarResult),
                    Erro = true
                };
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Excluir(int id)
        {
            var excluirResult = perfilAppService.Excluir(id);

            object retorno;
            if (excluirResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Registro Excluído com Sucesso",
                    Erro = false
                };
            }
            else
            {
                retorno = new
                {
                    Mensagem = RenderizeErros(excluirResult),
                    Erro = true
                };
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }


        #endregion
    }
}