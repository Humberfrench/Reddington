using System.Text.RegularExpressions;

namespace System.ComponentModel.DataAnnotations
{
    public class OnlyNumbersAttribute: ValidationAttribute
    {
        /// <summary>
        /// VERIFICA SE VALIDO
        /// </summary>
        /// <param name="aobjValor">VALOR DO OBJETO</param>
        /// <param name="aobjContexto">OBJETO DO CONTEXTO</param>
        /// <returns>RETORNA O RESULTADO DA VALIDAÇÃO</returns>
        protected override ValidationResult IsValid(object aobjValor, ValidationContext aobjContexto)
        {
            return this.ValidationValue(aobjValor, aobjContexto);
        }

        /// <summary>
        /// VALIDAÇÃO DO VALOR
        /// </summary>
        /// <param name="aobjValor">VALOR DO OBJETO</param>
        /// <param name="aobjContexto">OBJETO DO CONTEXTO</param>
        /// <returns>RESULTADO DA VALIDAÇÃO</returns>
        private ValidationResult ValidationValue(object aobjValor, ValidationContext aobjContexto)
        {
            if ((aobjValor == null) || (aobjValor.GetType() != typeof(string)))
            {
                return new ValidationResult(string.Format(ErrorMessageString, aobjContexto.DisplayName));
            }

            if (!Regex.IsMatch(((string)aobjValor), @"^[0-9]+$"))
            {
                return new ValidationResult(string.Format(ErrorMessageString, aobjContexto.DisplayName));
            }

            return ValidationResult.Success;
        }
    }
}
