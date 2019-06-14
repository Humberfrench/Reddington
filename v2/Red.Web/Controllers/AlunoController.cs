using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Red.Application.Interfaces;
using Red.Application.ViewModel;

namespace Red.Web.Controllers
{
    [RoutePrefix("Aluno")]
    public class AlunoController : Controller
    {
        private readonly IAlunoServiceApp alunoServiceApp;
        private readonly IResponsavelServiceApp responsavelServiceApp;
        private readonly IStatusServiceApp statusServiceApp;

        public AlunoController(IAlunoServiceApp alunoServiceApp,
                                 IResponsavelServiceApp responsavelServiceApp, 
                                 IStatusServiceApp statusAppService)
        {
            this.alunoServiceApp = alunoServiceApp;
            this.responsavelServiceApp = responsavelServiceApp;
            this.statusServiceApp = statusAppService;
        }

        // GET: Aluno
        [Route("")]
        public ActionResult Index()
        {
            var alunos = alunoServiceApp.ObterTodos();

            alunos = alunos.OrderBy(a => a.Nome).ToList();

            return View(alunos);
        }

        [Route("{id}")]
        public ActionResult Edit(int id)
        {
            var aluno = alunoServiceApp.ObterPorId(id);

            ViewBag.Status = statusServiceApp.ObterTodos();
            ViewBag.Responsavel = responsavelServiceApp.ObterTodos();

            return View("Aluno", aluno);
        }

        [Route("{new}")]
        public ActionResult Novo()
        {
            var aluno = new AlunoViewModel();

            ViewBag.Status = statusServiceApp.ObterTodos();
            ViewBag.Responsavel = responsavelServiceApp.ObterTodos();

            return View("Aluno", aluno);

        }


    }
}