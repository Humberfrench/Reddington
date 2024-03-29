﻿using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using French.Tools.DomainValidator;
using Red.Domain.Interfaces.Repository.UnitOfWork;
using Red.Repository.Context;
using Red.Repository.Interface;

namespace Red.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RedContext dbContext;
        private readonly ValidationResult validationResult;

        private bool disposed;

        public UnitOfWork(IContextManager contextManager)
        {
            this.dbContext = contextManager.GetContext();
            validationResult = new ValidationResult();
        }

        public void BeginTransaction()
        {
            this.disposed = false;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ValidationResult SaveChanges()
        {
#if DEBUG

            dbContext.ChangeTracker.DetectChanges(); // Force EF to match associations.
            var errors = dbContext.GetValidationErrors();
            var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
            var objectStateManager = objectContext.ObjectStateManager;
            var fieldInfo = objectStateManager.GetType().GetField("_entriesWithConceptualNulls", BindingFlags.Instance | BindingFlags.NonPublic);
            var conceptualNulls = fieldInfo.GetValue(objectStateManager);

#endif
            try
            {
                dbContext.Database.Log = Console.Write;
                this.dbContext.SaveChanges();
            }
            catch (DbEntityValidationException exValidation)
            {
                var erros = exValidation.EntityValidationErrors.ToList();
                if (erros.Any())
                {
                    erros.ForEach(e => e.ValidationErrors.ToList().ForEach(ev => validationResult.Add($"Erro de Validção ao Gravar: {ev.ErrorMessage}")));
                }
                else
                {
                    validationResult.Add(exValidation.Message);
                }
            }
            catch (DbUnexpectedValidationException ex)
            {
                validationResult.Add(ex.Message);
            }
            catch (Exception ex)
            {
                validationResult.Add(ex.Message);
                if (ex.Message == "An error occurred while updating the entries. See the inner exception for details.")
                {
                    var inner = ex.InnerException;
                    if (inner != null)
                    {
                        validationResult.Add(inner.Message);
                        var inner2 = inner.InnerException;
                        if (inner2 != null)
                        {
                            validationResult.Add(inner2.Message);
                        }
                    }
                }
            }
            return validationResult;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

    }
}
