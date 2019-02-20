using System.Collections.Generic;
using Red.Application.ViewModel;
using Red.DomainValidation;

namespace Red.Application.Interfaces
{
    public interface IProblemaSaudeServiceApp : IServiceBase<ProblemaSaudeViewModel>
    {
        IEnumerable<ProblemaSaudeViewModel> Filtrar(string nome);
        ValidationResult Gravar(ProblemaSaudeViewModel entity);
        ValidationResult Excluir(int id);
    }
}