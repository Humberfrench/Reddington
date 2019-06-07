using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Red.Web
{
    public class ElmahExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //context.Exception.

            //Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(context.Exception));
            Elmah.ErrorLog.GetDefault(HttpContext.Current)
                .Log(new Elmah.Error(actionExecutedContext.Exception, HttpContext.Current));
        }
    }
}