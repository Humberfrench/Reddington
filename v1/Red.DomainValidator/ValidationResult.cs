using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Red.DomainValidation
{
    [Serializable]
    public class ValidationResult
    {
        private readonly List<ValidationError> errors = new List<ValidationError>();

        public void Add(ValidationError error)
        {
            this.errors.Add(error);
        }

        public void Add(params ValidationResult[] validationResults)
        {
            if (validationResults != null)
            {
                foreach (var result in from result in validationResults
                                       where result != null
                                       select result)
                {
                    this.errors.AddRange(result.errors);
                }
            }
        }

        public void Add(string error)
        {
            var erro = new ValidationError(error);
            this.errors.Add(erro);
        }

        public void Remove(ValidationError error)
        {
            if (this.errors.Contains(error))
            {
                this.errors.Remove(error);
            }
        }

        public IEnumerable<ValidationError> Erros { get { return this.errors; } }

        public bool IsValid
        {
            get
            {
                return this.errors.Count == 0;
            }
        }

        public string Message { get; set; }

        [JsonIgnore]
        public bool ProblemaDeInfraestrutura { get; set; }
    }
}

