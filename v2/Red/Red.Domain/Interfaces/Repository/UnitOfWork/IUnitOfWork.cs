
using Credpay.Tools.DomainValidator;

namespace Credpay.BackOffice.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        ValidationResult SaveChanges();
    }
}