using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Red.Application.Interfaces;
using Red.Application.ViewModel;
using Red.Library;


namespace Red.Web.Controllers
{
    public class ResponsavelController : BaseController
    {
        #region Vars

        private readonly IResponsavelServiceApp responsavelAppService;

        #endregion

        #region Ctor

        public ResponsavelController(IResponsavelServiceApp responsavelAppService)
        {
            this.responsavelAppService = responsavelAppService;
        }

        #endregion

        #region Public Methods
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Responsável",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Responsável", ActionName = "Index", ControllerName = "Responsavel"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Responsavel"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaResponsavel = responsavelAppService.ObterTodos();
            return View(listaResponsavel);
        }

        [HttpGet]
        [Route("Filtrar/{nome?}")]
        public ActionResult Filtrar(string nome = "")
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Responsável",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Responsável", ActionName = "Index", ControllerName = "Responsavel"},
                 new BreadCrumb {LinkText = "Filtro", ActionName = "Filtro", ControllerName = "Responsavel"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion
            var listaGrupos = responsavelAppService.Filtrar(nome);

            return View("Index", listaGrupos);
        }

        public ActionResult Edit(int id)
        {
            var responsavelVm = responsavelAppService.ObterPorId(id);

            var responsavel = new
            {
                responsavelVm.Codigo,
                responsavelVm.Responsavel1,
                responsavelVm.Responsavel2,
                responsavelVm.Documento,
                responsavelVm.Telefone,
                responsavelVm.Celular1,
                responsavelVm.Celular2,
                responsavelVm.Endereco,
                responsavelVm.Cep,
                responsavelVm.Bairro,
                responsavelVm.Cidade,
                responsavelVm.Uf
            };

            return Json(responsavel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public ActionResult Gravar(ResponsavelViewModel responsavel)
        {
            var gravarResult = responsavelAppService.Gravar(responsavel);
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
            var excluirResult = responsavelAppService.Excluir(id);

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
                Titulo = "Responsável",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Responsável", ActionName = "Index", ControllerName = "Responsavel"},
                 new BreadCrumb {LinkText = "Alunos", ActionName = "Index", ControllerName = "Alunos"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion
            var responsavel = responsavelAppService.ObterPorId(id);
            TempData["Alunos"] = responsavel.Alunos;
            return RedirectToAction("Alunos", "Aluno");
        }

        public ActionResult ObterNomesParaPesquisa()
        {
            var listaNomes = responsavelAppService.ObterTodos().Select(dado => dado.Responsavel1);

            return Json(String.Join(", ", listaNomes.ToList()), JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}