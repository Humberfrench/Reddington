using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using Rendimento.AutenticacaoMultifatorial.Infra.CrossCutting.Core;

namespace Rendimento.AutenticacaoMultifatorial.Gerenciador.Controllers
{
    using Microsoft.Ajax.Utilities;
    using Rendimento.AutenticacaoMultifatorial.Aplicacao.Interfaces;
    using Rendimento.AutenticacaoMultifatorial.Aplicacao.ViewModels;
    using Rendimento.AutenticacaoMultifatorial.Infra.Core;

    public class AcessoController : BaseController
    {
        #region Vars
        
        private readonly IUsuarioAppService usuarioAppService;

        #endregion

        #region Ctor
        
        public AcessoController(IUsuarioAppService usuarioAppService)
        {
            this.usuarioAppService = usuarioAppService;
        }

        #endregion

        #region Public Methods

        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Dominio = AppSettings.Get("Dominio");

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UsuarioViewModel usuario)
        {
            var resultado = this.usuarioAppService.Autenticar(usuario);

            if (resultado.ValidationResult.IsValid == false)
            {
                var aviso = new Aviso
                {
                    TipoMensagem = Aviso.Tipo.Erro,
                    TituloMensagem = "Problemas com o formulário:"
                };

                resultado.ValidationResult.Erros.ForEach(x => aviso.Mensagens.Add(x.Message));

                TempData["Aviso"] = aviso;
                return View("Index");
            }

            AuthUser(resultado);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Sair()
        {
            //var retorno = usuarioAppService.Sair(TokenAcesso.UsuarioId);

            TokenAcesso = null;
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index");
        }


        [AllowAnonymous]
        [Route("404")]
        public ActionResult Erro404(string aspxerrorpath)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Página ou Recurso não encontrado",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Home", ActionName = "Index", ControllerName = "Home"},
                 new BreadCrumb {LinkText = "Página ou Recurso não encontrado", ActionName = "Erro404", ControllerName = "Acesso"}
                }
            };
            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            return View("Erro404");
        }

        [AllowAnonymous]
        [Route("500")]
        public ActionResult Erro500()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Ocorreu um erro interno",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Home", ActionName = "Index", ControllerName = "Home"},
                 new BreadCrumb {LinkText = "Erro", ActionName = "Erro500", ControllerName = "Acesso"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            return View("Erro500");
        }

        [AllowAnonymous]
        [Route("NaoAutorizado")]
        public ActionResult NaoAutorizado()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Home",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Home", ActionName = "Index", ControllerName = "Home"},
                 new BreadCrumb {LinkText = "Não Autorizado", ActionName = "NaoAutorizado", ControllerName = "Acesso"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            return View();
        }
        #endregion

        #region Private Methods
        private void AuthUser(TokenViewModel token)
        {
            var ticket = new FormsAuthenticationTicket
            (
            1,
            token.LoginAD,
            DateTime.Now,
            DateTime.Now.AddMinutes(Convert.ToInt32(FormsAuthentication.Timeout.TotalMinutes)),
            true,
            token.LoginAD,
            FormsAuthentication.FormsCookiePath
            );

            var cookie = new System.Web.HttpCookie(
                FormsAuthentication.FormsCookieName,
                FormsAuthentication.Encrypt(ticket)
                )
            {
                HttpOnly = true
            };

            Response.Cookies.Add(cookie);

            TokenAcesso = token;

        }
        #endregion
    }
}