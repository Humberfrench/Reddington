﻿using System.Collections.Generic;
using System.Linq;
using Red.Domain.Entities;
using Red.Domain.Interfaces.Repository;
using Red.Domain.Interfaces.Service;
using Red.Domain.Service;
using Red.DomainValidation;

namespace Red.Domain.Service
{
    public class CaracteristicaService : ServiceBase<Caracteristica>, ICaracteristicaService
    {
        private readonly ICaracteristicaRepository repository;
        private readonly ValidationResult validationResult = new ValidationResult();

        public CaracteristicaService(ICaracteristicaRepository repository)
            : base(repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Caracteristica> Filtrar(string nome)
        {
            var registros = Pesquisar(p => p.Descricao.ToLower().Contains(nome.ToLower())).ToList();
            return registros;
        }

        public ValidationResult Gravar(Caracteristica item)
        {
            if (item.Codigo == 0)
            {
                Adicionar(item);
            }
            else
            {
                Atualizar(item);
            }

            return validationResult;
        }

        public ValidationResult Excluir(int id)
        {
            var item = ObterPorId(id);

            if (item == null)
            {
                validationResult.Add(new ValidationError("Registro não encontrado"));
                return validationResult;
            }

            repository.Excluir(item);

            return validationResult;

        }


    }
}
