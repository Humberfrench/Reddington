using Red.Domain.Entities.Specifications.Aluno;
using Red.DomainValidation;

namespace Red.Domain.Entities.Validations
{
    public class AlunoIsValidValidation : Validator<Aluno>
    {
        public AlunoIsValidValidation()
        {
            base.AdicionarRegra("Idade Mínima 5 Anos",new Rule<Aluno>(new AlunoIdadeMinimaCinco(), "Idade Mínima para Matrícula é de 5 Anos"));
        }
    }
}
