using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Red.Application.Interfaces;
using Red.Application.ViewModel;
using Red.Library;

namespace Red.Web.Controllers
{
    public class AtividadePreferidaController : BaseController
    {
        #region Vars

        private readonly IAtividadePreferidaServiceApp atividadePreferidaAppService;

        #endregion

        #region Ctor

        public AtividadePreferidaController(IAtividadePreferidaServiceApp atividadePreferidaAppService)
        {
            this.atividadePreferidaAppService = atividadePreferidaAppService;
        }

        #endregion

        #region Public Methods
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Atividades Preferidas",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Atividades Preferidas", ActionName = "Index", ControllerName = "AtividadePreferida"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "AtividadePreferida"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaGrupos = atividadePreferidaAppService.ObterTodos();
            return View(listaGrupos);
        }

        [HttpGet]
        [Route("Filtrar/{nome?}")]
        public ActionResult Filtrar(string nome = "")
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Atividades Preferidas",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Atividades Preferidas", ActionName = "Index", ControllerName = "AtividadePreferida"},
                 new BreadCrumb {LinkText = "Filtro", ActionName = "Filtro", ControllerName = "AtividadePreferida"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion
            var listaGrupos = atividadePreferidaAppService.Filtrar(nome);

            return View("Index", listaGrupos);
        }

        public ActionResult Edit(int id)
        {
            var grupo = atividadePreferidaAppService.ObterPorId(id);
            return Json(grupo, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public ActionResult Gravar(AtividadePreferidaViewModel atividadePreferida)
        {
            var gravarResult = atividadePreferidaAppService.Gravar(atividadePreferida);
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
            var excluirResult = atividadePreferidaAppService.Excluir(id);

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
                Titulo = "Atividade Prefererida",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Atividade Prefererida", ActionName = "Index", ControllerName = "AtividadePrefererida"},
                 new BreadCrumb {LinkText = "Alunos", ActionName = "Index", ControllerName = "Alunos"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion
            var responsavel = atividadePreferidaAppService.ObterPorId(id);
            TempData["Alunos"] = responsavel.Alunos;
            return RedirectToAction("Alunos", "Aluno");
        }


        public ActionResult ObterNomesParaPesquisa()
        {
            var listaNomes = atividadePreferidaAppService.ObterTodos().Select(dado => dado.Descricao);

            return Json(String.Join(", ", listaNomes.ToList()), JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}