namespace Red.DomainValidation.Interfaces
{
    public interface IRule<in TEntity>
    {
        string MensagemErro { get; }
        bool Validar(TEntity entity);
    }
}
