using System;

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// VERIFICA SE É MENOR QUE
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class IsLessAttribute : ValidationAttribute
    {
        /// <summary>
        /// NOME DA PROPRIEDADE
        /// </summary>
        private readonly string pstrNomePropriedade;

        /// <summary>
        /// VALOR DO OBJETO
        /// </summary>
        private readonly object pobjValor;

        /// <summary>
        /// Initializes a new instance of the IsLessAttribute class
        /// </summary>
        /// <param name="astrNomePropriedadeDependente">NOME DA PROPRIEDADE</param>
        public IsLessAttribute(string astrNomePropriedadeDependente)
        {
            this.pstrNomePropriedade = astrNomePropriedadeDependente;
            this.pobjValor = null;
        }

        /// <summary>
        /// Initializes a new instance of the IsLessAttribute class
        /// </summary>
        /// <param name="aobjValor">VALOR DO OBJETO</param>
        public IsLessAttribute(object aobjValor)
        {
            this.pobjValor = aobjValor;
            this.pstrNomePropriedade = null;
        }

        /// <summary>
        /// Gets nome da propriedade dependente
        /// </summary>
        /// <value>Valor o do objeto</value>
        public string NomePropriedadeDependente
        {
            get { return this.pstrNomePropriedade; }
        }

        /// <summary>
        /// Gets Valor da propriedade dependente
        /// </summary>
        /// <value>Valor o do objeto</value>
        public object Valor
        {
            get { return this.pobjValor; }
        }

        /// <summary>
        /// VERIFICA SE VALIDO
        /// </summary>
        /// <param name="aobjValor">VALOR DO OBJETO</param>
        /// <param name="aobjContexto">OBJETO DO CONTEXTO</param>
        /// <returns>RETORNA O RESULTADO DA VALIDAÇÃO</returns>
        protected override ValidationResult IsValid(object aobjValor, ValidationContext aobjContexto)
        {
            return this.pobjValor != null ? this.ValidationValue(aobjValor, aobjContexto) : this.ValidationAttribute(aobjValor, aobjContexto);
        }

        /// <summary>
        /// VERIFICA O ATRIBUTO
        /// </summary>
        /// <param name="aobjValor">VALOR DO OBJETO</param>
        /// <param name="aobjContexto">OBJETO DO CONTEXTO</param>
        /// <returns>RESULTADO DA VALIDAÇÃO</returns>
        private ValidationResult ValidationAttribute(object aobjValor, ValidationContext aobjContexto)
        {
            var lobjPropriedade = aobjContexto.ObjectInstance.GetType().GetProperty(this.pstrNomePropriedade);
            var lobjValorPropriedade = lobjPropriedade.GetValue(aobjContexto.ObjectInstance, null);

            if (lobjValorPropriedade != null)
            {
                if ((DateTime)lobjValorPropriedade == DateTime.MinValue)
                {
                    lobjValorPropriedade = null;
                    return new ValidationResult(string.Format(ErrorMessageString, aobjContexto.DisplayName));
                }
            }

            if (lobjValorPropriedade != null && aobjValor != null)
            {
                if (aobjValor.GetType() == typeof(DateTime))
                {
                    if (((DateTime)aobjValor) < ((DateTime)lobjValorPropriedade))
                    {
                        return new ValidationResult(string.Format(ErrorMessageString, aobjContexto.DisplayName));
                    }
                }
                else if (((decimal)aobjValor) < ((decimal)lobjValorPropriedade))
                {
                    return new ValidationResult(string.Format(ErrorMessageString, aobjContexto.DisplayName));
                }
            }

            return ValidationResult.Success;
        }

        /// <summary>
        /// VALIDAÇÃO DO VALOR
        /// </summary>
        /// <param name="aobjValor">VALOR DO OBJETO</param>
        /// <param name="aobjContexto">OBJETO DO CONTEXTO</param>
        /// <returns>RESULTADO DA VALIDAÇÃO</returns>
        private ValidationResult ValidationValue(object aobjValor, ValidationContext aobjContexto)
        {
            if ((aobjValor == null && this.pobjValor == null) || (aobjValor.GetType() != this.pobjValor.GetType()))
            {
                return new ValidationResult(string.Format(ErrorMessageString, aobjContexto.DisplayName));
            }

            if (aobjValor.GetType() == typeof(DateTime))
            {
                if (((DateTime)aobjValor) < ((DateTime)this.pobjValor))
                {
                    return new ValidationResult(string.Format(ErrorMessageString, aobjContexto.DisplayName));
                }
            }
            else if (decimal.Parse(aobjValor.ToString()) < decimal.Parse(this.pobjValor.ToString()))
            {
                return new ValidationResult(string.Format(ErrorMessageString, aobjContexto.DisplayName));
            }

            return ValidationResult.Success;
        }
    }
}
