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
    [RoutePrefix("GrupoManutencao")]
    public class GrupoManutencaoController : BaseController
    {
        #region Vars

        private readonly IGrupoManutencaoAppService grupoManutencaoAppService;

        #endregion

        #region Ctor

        public GrupoManutencaoController(IGrupoManutencaoAppService perfilAppService)
        {
            this.grupoManutencaoAppService = perfilAppService;
        }

        #endregion

        #region Public Methods
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Grupo de Manutenção",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Grupo de Manutenção", ActionName = "Index", ControllerName = "GrupoManutencao"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "GrupoManutencao"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaPerfis = grupoManutencaoAppService.ObterTodos();
            return View(listaPerfis);
        }

        [HttpGet]
        [Route("Filtrar/{status}/{nome?}")]
        public ActionResult Filtrar(int status, string nome = "")
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Grupo de Manutenção",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Grupo de Manutenção", ActionName = "Index", ControllerName = "GrupoManutencao"},
                 new BreadCrumb {LinkText = "Filtro", ActionName = "Filtro", ControllerName = "GrupoManutencao"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion
            var listaPerfis = grupoManutencaoAppService.Filtrar(status, nome);

            return View("Index", listaPerfis);
        }

        public ActionResult Edit(int id)
        {
            var retorno = grupoManutencaoAppService.ObterPorId(id);

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public ActionResult Gravar(GrupoManutencaoViewModel grupoManutencao)
        {
            var gravarResult = grupoManutencaoAppService .Gravar(grupoManutencao);
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
            var excluirResult = grupoManutencaoAppService.Excluir(id);

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

        public ActionResult ObterNomesParaPesquisa()
        {
            var listaNomes = grupoManutencaoAppService.ObterTodos().Select(dado => dado.Nome);

            return Json(String.Join(", ", listaNomes.ToList()), JsonRequestBehavior.AllowGet);
        }

        #endregion


    }
}