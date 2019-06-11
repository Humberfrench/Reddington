using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using French.Tools.DomainValidator;
using Red.Domain.Entity;
using Red.Domain.Interfaces.Repository;
using Red.Domain.Interfaces.Services;
using French.Tools.Extensions;

namespace Red.Services
{
    public class AtividadesPreferidasService : ServiceBase<AtividadesPreferidas>, IAtividadesPreferidasService
    {
        private readonly IAtividadesPreferidasRepository repAtividadesPreferidas;
        private readonly ValidationResult validationResult;

        public AtividadesPreferidasService(IAtividadesPreferidasRepository repAtividadesPreferidas) : base(repAtividadesPreferidas)
        {
            this.repAtividadesPreferidas = repAtividadesPreferidas;
            validationResult = new ValidationResult();
        }

        public ValidationResult Excluir(int id)
        {
            var entity = repAtividadesPreferidas.ObterPorId(id);

            if (entity == null)
            {
                validationResult.Add("Registro não encontrado.");
                return validationResult;
            }

            repAtividadesPreferidas.Excluir(entity);

            return validationResult;

        }

        public ValidationResult Gravar(AtividadesPreferidas entity)
        {
            if (entity.Descricao.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Preencher campo Nome.");
                return validationResult;
            }

             var novo = entity.AtividadesPreferidasId == 0;
            if (novo)
            {
                repAtividadesPreferidas.Adicionar(entity);
            }
            else
            {
                repAtividadesPreferidas.Atualizar(entity);
            }

            return validationResult;

        }
    }
}
