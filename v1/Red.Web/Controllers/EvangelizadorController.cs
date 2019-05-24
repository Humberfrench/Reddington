using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Red.Application.Interfaces;
using Red.Application.ViewModel;
using Red.Library;

namespace Red.Web.Controllers
{
    public class EvangelizadorController : BaseController
    {
        #region Vars

        private readonly IEvangelizadorServiceApp evangelizadorAppService;

        #endregion

        #region Ctor

        public EvangelizadorController(IEvangelizadorServiceApp evangelizadorAppService)
        {
            this.evangelizadorAppService = evangelizadorAppService;
        }

        #endregion

        #region Public Methods
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Evangelizadores",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Evangelizadores", ActionName = "Index", ControllerName = "Evangelizador"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Evangelizador"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaGrupos = evangelizadorAppService.ObterTodos();
            return View(listaGrupos);
        }

        [HttpGet]
        [Route("Filtrar/{nome?}")]
        public ActionResult Filtrar(string nome = "")
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Evangelizadores",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Evangelizadores", ActionName = "Index", ControllerName = "Evangelizador"},
                 new BreadCrumb {LinkText = "Filtro", ActionName = "Filtro", ControllerName = "Evangelizador"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion
            var listaGrupos = evangelizadorAppService.Filtrar(nome);

            return View("Index", listaGrupos);
        }

        public ActionResult Edit(int id)
        {
            var evangelizador = evangelizadorAppService.ObterPorId(id);

            var evangelizadorResponse = new
            {
                evangelizador.Codigo,
                evangelizador.Nome,
                evangelizador.Contato,
                evangelizador.Email
            };

            return Json(evangelizadorResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public ActionResult Gravar(EvangelizadorViewModel evangelizador)
        {
            var gravarResult = evangelizadorAppService .Gravar(evangelizador);
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
            var excluirResult = evangelizadorAppService.Excluir(id);

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


        public ActionResult Alunos(int id)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Evangelizadores",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Evangelizadores", ActionName = "Index", ControllerName = "Evangelizador"},
                 new BreadCrumb {LinkText = "Alunos", ActionName = "Index", ControllerName = "Alunos"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion
            var responsavel = evangelizadorAppService.ObterPorId(id);
            TempData["Turmas"] = responsavel.Turmas;
            return RedirectToAction("Alunos", "Aluno");
        }

        #endregion
    }
}