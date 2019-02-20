using System;

namespace Red.DomainValidation
{
    [Serializable]
    public class ValidationError
    {
        public ValidationError(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }
    }
}

