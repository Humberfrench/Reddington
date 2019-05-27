using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using French.Tools.DomainValidator;

namespace Red.Application.Interfaces
{
    public interface IServiceBase
    {
        void BeginTransaction();

        void Commit();
    }
}