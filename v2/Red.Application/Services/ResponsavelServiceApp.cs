﻿using System;
using System.Collections.Generic;
using French.Tools.DomainValidator;
using Red.Application.Interfaces;
using Red.Application.ViewModel;
using Red.Domain.Entity;
using Red.Domain.Interfaces.Repository.UnitOfWork;
using Red.Domain.Interfaces.Services;

namespace Red.Application.Services
{
    public class ResponsavelServiceApp : BaseServiceApp, IResponsavelServiceApp
    {

        private readonly IResponsavelService responsavelService;

        public ResponsavelServiceApp(IResponsavelService responsavelService, IUnitOfWork uow) : base(uow)
        {
            this.responsavelService = responsavelService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IList<ResponsavelViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public ResponsavelViewModel ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Gravar(ResponsavelViewModel item)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}