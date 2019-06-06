using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Red.Application.Interfaces;

namespace Red.Web.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoServiceApp alunoServiceApp;

        public AlunoController(IAlunoServiceApp alunoServiceApp)
        {
            this.alunoServiceApp = alunoServiceApp;
        }
        // GET: Aluno
        public ActionResult Index()
        {
            var alunos = alunoServiceApp.ObterTodos();
            return View(alunos);
        }
    }
}