using System.Collections.Generic;
using System.Web.Mvc;
using Red.Library;

namespace Red.Web.Controllers
{

    public class SiteController : BaseController
    {

        #region Public Methods

        public ActionResult TituloEBreadCrumb()
        {
            var breadCrumb = (BreadCrumbETitulo)this.TempData["BreadCrumETitulo"]
                             ?? new BreadCrumbETitulo { Titulo = "Não definido", BreadCrumbs = new List<BreadCrumb>() };

            return this.PartialView(breadCrumb);
        }


        public ActionResult MenuLateral()
        {
            @ViewBag.Usuario = "";
            @ViewBag.Perfil = "";
            return PartialView("_Navigation");
        }

        #endregion
    }
}