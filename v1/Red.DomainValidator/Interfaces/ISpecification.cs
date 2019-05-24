namespace Red.DomainValidation.Interfaces
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T entidade);
    }
}
