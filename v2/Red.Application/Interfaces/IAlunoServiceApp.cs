using Red.Application.ViewModel;
using French.Tools.DomainValidator;
using System.Collections.Generic;

namespace Red.Application.Interfaces
{
    public interface IAlunoServiceApp : IServiceBaseApp<AlunoViewModel>
    {
        List<AlunoViewModel> ObterTodosPorStatus(int statusId);

    }
}