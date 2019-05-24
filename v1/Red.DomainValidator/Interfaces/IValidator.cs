namespace Red.DomainValidation.Interfaces
{
    public interface IValidator<in TEntity>
    {
        ValidationResult Validar(TEntity entity);
    }
}
