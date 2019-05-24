using System.Web;
using Red.Repository.Interface;

namespace Red.Repository.Context
{
    public class ContextManager : IContextManager
    {
    private const string ContextKey = "ContextManager.Context";

    public RedContext GetContext()
    {
        if (HttpContext.Current == null)
            return new RedContext();

        if (HttpContext.Current.Items[ContextKey] == null)
        {
            HttpContext.Current.Items[ContextKey] = new RedContext();
        }

        return HttpContext.Current.Items[ContextKey] as RedContext;
    }
    }
}