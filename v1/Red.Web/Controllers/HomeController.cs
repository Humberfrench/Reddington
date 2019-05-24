using System.Collections.Generic;
using System.Web.Mvc;
using Red.Library;

namespace Red.Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Home",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Home", ActionName = "Index", ControllerName = "Home"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            return View();
        }
    }
}