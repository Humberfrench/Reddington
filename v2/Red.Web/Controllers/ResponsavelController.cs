using Red.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Red.Web.Controllers
{
    public class ResponsavelController : Controller
    {
        private readonly IResponsavelServiceApp ResponsavelServiceApp;

        public ResponsavelController(IResponsavelServiceApp ResponsavelServiceApp)
        {
            this.ResponsavelServiceApp = ResponsavelServiceApp;
        }
        // GET: Responsavel
        public ActionResult Index()
        {
            var responsaveis = ResponsavelServiceApp.ObterTodos();

            responsaveis = responsaveis.OrderBy(a => a.Responsavel1).ToList();

            return View(responsaveis);
        }
    }
}