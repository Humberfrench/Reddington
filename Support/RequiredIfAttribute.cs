namespace System.ComponentModel.DataAnnotations
{
    using System;

    /// <summary>
    /// Obrigatoriedade do atributo
    /// </summary>

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public sealed class RequiredIfAttribute : ValidationAttribute
    {
        /// <summary>
        /// NOME DA PROP
        /// </summary>
        private readonly string pstrNomePropriedade;

        /// <summary>
        /// ENUM DO OPERADOR
        /// </summary>
        private readonly Operador penmOperador;

        /// <summary>
        /// VALOR DA PROP
        /// </summary>
        private readonly object pobjValPropDep;

        /// <summary>
        /// Initializes a new instance of the RequiredIfAttribute class
        /// </summary>
        /// <param name="astrNomePropriedadeDependente">NOME DA PROPRIEDADE</param>
        /// <param name="aenmOperador">ENUM DO OPERADOR</param>
        /// <param name="aobjValorPropriedadeDependente">VALOR DA PROPRIEDADE</param>
        public RequiredIfAttribute(string astrNomePropriedadeDependente, Operador aenmOperador, object aobjValorPropriedadeDependente)
        {
            this.pstrNomePropriedade = astrNomePropriedadeDependente;
            this.penmOperador = aenmOperador;
            this.pobjValPropDep = aobjValorPropriedadeDependente;
        }

        /// <summary>
        /// Gets Nome da propriedade dependente
        /// </summary>
        /// <value>Valor o do objeto</value>
        public string NomePropDependente
        {
            get { return this.pstrNomePropriedade; }
        }

        /// <summary>
        /// Gets Operação a ser realizada
        /// </summary>
        /// <value>Valor o do objeto</value>
        public Operador Operacao
        {
            get { return this.penmOperador; }
        }

        /// <summary>
        /// Gets Valor da propriedade dependente
        /// </summary>
        /// <value>Valor o do objeto</value>
        public object ValPropDependente
        {
            get { return this.pobjValPropDep; }
        }

        public override object TypeId
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// VERIFICA SE VALIDO
        /// </summary>
        /// <param name="aobjValor">VALOR DO OBJETO</param>
        /// <param name="aobjContexto">OBJETO DO CONTEXTO</param>
        /// <returns>RETORNA O RESULTADO DA VALIDAÇÃO</returns>
        protected override ValidationResult IsValid(object aobjValor, ValidationContext aobjContexto)
        {
            if (aobjContexto != null)
            {
                // Se objeto não for string e for diferente de nulo ou se dor string e o comprimento for maior que zero. 
                // O campo está preenchido.
                bool lbooValida = (aobjValor != null && aobjValor.GetType() != typeof(string)) ||
                                  (aobjValor != null && aobjValor.GetType() == typeof(string) && aobjValor.ToString().Trim().Length > 0);

                if (lbooValida)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    var lobjPropriedade = aobjContexto.ObjectInstance.GetType().GetProperty(this.pstrNomePropriedade);
                    var lobjValorPropriedade = lobjPropriedade.GetValue(aobjContexto.ObjectInstance, null);

                    if (this.validarPropDependente(lobjValorPropriedade))
                    {
                        return new ValidationResult(string.Format(ErrorMessageString, aobjContexto.DisplayName));
                    }
                }
            }

            return ValidationResult.Success;
        }

        /// <summary>
        /// VALIDAR A PROPRIEDADE
        /// </summary>
        /// <param name="aobjValPropReal">VALOR DA PROPRIEDADE</param>
        /// <returns>RESULTADO DA VALIDAÇÃO</returns>
        private bool validarPropDependente(object aobjValPropReal)
        {
            switch (this.penmOperador)
            {
                case Operador.IsLessTo:
                    return aobjValPropReal == null ? this.pobjValPropDep != null : decimal.Parse(aobjValPropReal.ToString()) < decimal.Parse(this.pobjValPropDep.ToString());
                case Operador.IsGreaterTo:
                    return aobjValPropReal == null ? this.pobjValPropDep != null : decimal.Parse(aobjValPropReal.ToString()) > decimal.Parse(this.pobjValPropDep.ToString());
                case Operador.IsLessOrEqualTo:
                    return aobjValPropReal == null ? this.pobjValPropDep != null : decimal.Parse(aobjValPropReal.ToString()) <= decimal.Parse(this.pobjValPropDep.ToString());
                case Operador.IsGreaterOrEqualTo:
                    return aobjValPropReal == null ? this.pobjValPropDep != null : decimal.Parse(aobjValPropReal.ToString()) >= decimal.Parse(this.pobjValPropDep.ToString());
                case Operador.IsNotEqualTo:
                    return aobjValPropReal == null ? this.pobjValPropDep != null : !aobjValPropReal.Equals(this.pobjValPropDep);
                default:
                    return aobjValPropReal == null ? this.pobjValPropDep == null : aobjValPropReal.Equals(this.pobjValPropDep);
            }
        }
    }
}