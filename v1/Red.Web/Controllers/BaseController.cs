using Red.DomainValidation;
using Red.Library;
using System.Web.Mvc;

namespace Red.Web.Controllers
{
    [NoCache]
    public class BaseController : Controller
    {

        protected string RenderizeErros(ValidationResult resultValue)
        {

            string retorno = string.Empty;

            foreach (ValidationError itemErro in resultValue.Erros)
            {
                var retornoTemp = string.Format("- {0} <br />", itemErro.Message);
                retorno += retornoTemp;
            }

            return retorno;
        }

    }
}
