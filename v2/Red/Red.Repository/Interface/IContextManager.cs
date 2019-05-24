using Red.Repository.Context;

namespace Red.Repository.Interface
{
    public interface IContextManager
    {
        RedContext GetContext();
    }
}