﻿using System;
using System.Collections.Generic;
using French.Tools.DomainValidator;
using Red.Application.Interfaces;
using Red.Domain.Interfaces.Repository.UnitOfWork;
using Red.Domain.Interfaces.Services;

namespace Red.Application.Services
{
    public class ProblemaSaudeServiceApp : BaseServiceApp, IProblemaSaudeServiceApp
    {

        private readonly IProblemasDeSaudeService problemaSaudeService;

        public ProblemaSaudeServiceApp(IProblemasDeSaudeService problemaSaudeService, IUnitOfWork uow) : base(uow)
        {
            this.problemaSaudeService = problemaSaudeService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
