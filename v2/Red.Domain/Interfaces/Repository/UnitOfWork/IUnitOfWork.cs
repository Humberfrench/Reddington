using French.Tools.DomainValidator;

namespace Red.Domain.Interfaces.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        ValidationResult SaveChanges();
        void Dispose();
    }
}