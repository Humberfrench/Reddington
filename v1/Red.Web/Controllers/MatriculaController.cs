using Red.Application.Interfaces;
using Red.Application.ViewModel;
using Red.Library;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Red.Web.Controllers
{
    [RoutePrefix("Matricula")]
    public class MatriculaController : BaseController
    {
        private readonly IResponsavelServiceApp responsavel;
        public MatriculaController(IResponsavelServiceApp responsavel)
        {
            this.responsavel = responsavel;
        }
        [Route("")]
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Alunos",
                BreadCrumbs = new List<BreadCrumb>
                {
                    new BreadCrumb {LinkText = "Alunos", ActionName = "Index", ControllerName = "Aluno"},
                    new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Aluno"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var responsaveis = responsavel.ObterTodos();

            return View(responsaveis);
        }
        [Route("{id}")]
        public ActionResult Index(int id)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Alunos",
                BreadCrumbs = new List<BreadCrumb>
                {
                    new BreadCrumb {LinkText = "Alunos", ActionName = "Index", ControllerName = "Aluno"},
                    new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Aluno"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var responsaveis = responsavel.ObterPorId(id);
            var retorno = new List<ResponsavelViewModel> { responsaveis };

            return View(retorno);

        }
    }
}