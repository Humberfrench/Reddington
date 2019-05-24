using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Red.Application.Interfaces;
using Red.Application.ViewModel;
using Red.Library;

namespace Red.Web.Controllers
{
    public class CaracteristicaController : BaseController
    {
        #region Vars

        private readonly ICaracteristicaServiceApp caracteristicaAppService;

        #endregion

        #region Ctor

        public CaracteristicaController(ICaracteristicaServiceApp caracteristicaAppService)
        {
            this.caracteristicaAppService = caracteristicaAppService;
        }

        #endregion

        #region Public Methods
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Características",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Características", ActionName = "Index", ControllerName = "Caracteristica"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Caracteristica"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaGrupos = caracteristicaAppService.ObterTodos();
            return View(listaGrupos);
        }

        [HttpGet]
        [Route("Filtrar/{nome?}")]
        public ActionResult Filtrar(string nome = "")
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Características",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Características", ActionName = "Index", ControllerName = "Caracteristica"},
                 new BreadCrumb {LinkText = "Filtro", ActionName = "Filtro", ControllerName = "Caracteristica"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion
            var listaGrupos = caracteristicaAppService.Filtrar(nome);

            return View("Index", listaGrupos);
        }

        public ActionResult Edit(int id)
        {
            var grupo = caracteristicaAppService.ObterPorId(id);
            return Json(grupo, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public ActionResult Gravar(CaracteristicaViewModel caracteristica)
        {
            var gravarResult = caracteristicaAppService .Gravar(caracteristica);
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
            var excluirResult = caracteristicaAppService.Excluir(id);

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
                Titulo = "Característica",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Característica", ActionName = "Index", ControllerName = "Caracteristica"},
                 new BreadCrumb {LinkText = "Alunos", ActionName = "Index", ControllerName = "Alunos"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion
            var responsavel = caracteristicaAppService.ObterPorId(id);
            TempData["Alunos"] = responsavel.Alunos;
            return RedirectToAction("Alunos", "Aluno");
        }

        public ActionResult ObterNomesParaPesquisa()
        {
            var listaNomes = caracteristicaAppService.ObterTodos().Select(dado => dado.Descricao);

            return Json(String.Join(", ", listaNomes.ToList()), JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}