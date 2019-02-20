using Red.Application.ViewModel;
using Red.DomainValidation;
using System.Collections.Generic;

namespace Red.Application.Interfaces
{
    public interface IAlunoServiceApp : IServiceBase<AlunoViewModel>
    {
        IEnumerable<AlunoViewModel> Filtrar(string nome);
        IEnumerable<AlunoViewModel> ObterTodosAtivos();
        IEnumerable<AlunoViewModel> ObterTodosNaoAtivos();
        ValidationResult Gravar(AlunoViewModel entity);
        ValidationResult Excluir(int id);
    }
}