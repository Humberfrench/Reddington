using System;
using Red.DomainValidation;
using Red.Domain.Entities;
using Red.DomainValidation.Interfaces;

namespace Red.Domain.Entities.Specifications.Aluno
{
    public class AlunoIdadeMinimaCinco : ISpecification<Entities.Aluno>
    {
        public bool IsSatisfiedBy(Entities.Aluno aluno)
        {
            return ((aluno.DataNascimento - DateTime.Now).Days / 365) > 5;
        }
    }
}
