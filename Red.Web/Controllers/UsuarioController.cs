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
    [RoutePrefix("Usuario")]
    public class UsuarioController : BaseController
    {
        #region Vars

        private readonly IUsuarioAppService usuarioAppService;
        private readonly IPerfilAppService perfilAppService;

        #endregion

        #region Ctor

        public UsuarioController(IUsuarioAppService usuarioAppService, 
                                 IPerfilAppService perfilAppService)
        {
            this.usuarioAppService = usuarioAppService;
            this.perfilAppService = perfilAppService;
        }

        #endregion

        #region Public Methods
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Usuário",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Usuario", ActionName = "Index", ControllerName = "Usuario"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Usuario"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaUsuario = usuarioAppService.ObterTodos();
            ViewBag.Perfil = ObterListaPerfilParaCombo();
            
            return View(listaUsuario);
        }

        [HttpGet]
        [Route("Filtrar/{status}/{nome?}")]
        public ActionResult Filtrar(int status, string nome = "")
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Usuário",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Usuario", ActionName = "Index", ControllerName = "Usuario"},
                 new BreadCrumb {LinkText = "Filtro", ActionName = "Filtro", ControllerName = "Usuario"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaUsuario = usuarioAppService.Filtrar(status, nome);
            ViewBag.Perfil = ObterListaPerfilParaCombo();

            return View("Index", listaUsuario);
        }

        public ActionResult Edit(int id)
        {
            var retorno = usuarioAppService.ObterPorId(id);

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public ActionResult Gravar(UsuarioViewModel usuario)
        {
            var gravarResult = usuarioAppService.Gravar(usuario);
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
            var excluirResult = usuarioAppService.Excluir(id);

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

        public ActionResult ObterUsuarioViaAD(string login)
        {
            var dominio = AppSettings.Get("Dominio");

            var usuario = usuarioAppService.ObterUsuarioViaAD(login, dominio);
            if (usuario == null)
            {
                usuario = new UsuarioViewModel();
            }

            return Json(usuario, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region private methods
        SelectList ObterListaPerfilParaCombo()
        {
            var listaPerfis = perfilAppService.ObterTodos();
            var perfilList = new SelectList(listaPerfis, "PerfilId", "Nome");

            return perfilList;
        }

        #endregion

    }
}