﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class IsEqualAttribute : ValidationAttribute
    {
        /// <summary>
        /// NOME DA PROPRIEDADE
        /// </summary>
        private readonly string pstrNomePropriedade;

        private readonly Type[] plstNumericTypes = new Type[6] { typeof(Int16), typeof(Int32), typeof(Int64), typeof(decimal), typeof(double), typeof(float) };

        /// <summary>
        /// VALOR DO OBJETO
        /// </summary>
        private readonly object pobjValor;

        /// <summary>
        /// Initializes a new instance of the IsGreaterAttribute class
        /// </summary>
        /// <param name="astrNomePropriedadeDependente">NOME DA PROPRIEDADE</param>
        public IsEqualAttribute(string astrNomePropriedadeDependente)
        {
            this.pstrNomePropriedade = astrNomePropriedadeDependente;
            this.pobjValor = null;
        }

        /// <summary>
        /// Initializes a new instance of the IsGreaterAttribute class
        /// </summary>
        /// <param name="aobjValor">VALOR DO OBJETO</param>
        public IsEqualAttribute(object aobjValor)
        {

            this.pobjValor = plstNumericTypes.Contains(aobjValor.GetType()) ? decimal.Parse(aobjValor.ToString()) : aobjValor;
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
            if (plstNumericTypes.Contains(aobjValor.GetType()))
            {
                decimal ldecValueCompare = decimal.Parse(aobjValor.ToString());

                aobjValor = ldecValueCompare;
            }

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
                    if (((DateTime)aobjValor) == ((DateTime)lobjValorPropriedade))
                    {
                        return new ValidationResult(string.Format(ErrorMessageString, aobjContexto.DisplayName));
                    }
                }
                else if (((decimal)aobjValor) == ((decimal)lobjValorPropriedade))
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
                if (((DateTime)aobjValor) == ((DateTime)this.pobjValor))
                {
                    return new ValidationResult(string.Format(ErrorMessageString, aobjContexto.DisplayName));
                }
            }
            else if (decimal.Parse(aobjValor.ToString()) == decimal.Parse(this.pobjValor.ToString()))
            {
                return new ValidationResult(string.Format(ErrorMessageString, aobjContexto.DisplayName));
            }

            return ValidationResult.Success;
        }
    }
}
