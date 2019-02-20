using Rendimento.InternetBanking.Infra.Core;
using System;
using System.Collections;

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Condição If para atributos
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public sealed class IfAttribute : ValidationAttribute
    {
        /// <summary>
        /// NOME DA PROPRIEDADE
        /// </summary>
        private readonly string pstrNomePro;

        /// <summary>
        /// NOME DA PROPRIEDADE A SER COMPARADA
        /// </summary>
        private readonly string pstrNomeProCom;

        /// <summary>
        /// ENUM DO OPERADOR
        /// </summary>
        private readonly Operador penmOperador;

        /// <summary>
        /// VALOR DA PROP
        /// </summary>
        private readonly object pobjValPropDep;

        /// <summary>
        /// Identificador exclusivo para propriedade associada a validação
        /// </summary>
        private readonly object pobjId = new object();

        /// <summary>
        /// Initializes a new instance of the IfAttribute class
        /// </summary>
        /// <param name="astrNomePro">NOME DA PROPRIEDADE</param>
        /// <param name="aenmOperador">ENUM DO OPERADOR</param>
        /// <param name="aobjValPro">VALOR DA PROPRIEDADE</param>
        public IfAttribute(string astrNomePro, Operador aenmOperador, object aobjValPro)
        {
            this.pstrNomePro = astrNomePro;
            this.penmOperador = aenmOperador;
            this.pobjValPropDep = aobjValPro;
        }

        /// <summary>
        /// Initializes a new instance of the IfAttribute class
        /// </summary>
        /// <param name="astrNomePro">NOME DA PROPRIEDADE</param>
        /// <param name="astrNomeProCom">NOME DA PROPRIEDADE A SER COMPARADA</param>
        /// <param name="aenmOperador">ENUM DO OPERADOR</param>
        public IfAttribute(string astrNomePro, string astrNomeProCom, Operador aenmOperador)
        {
            this.pstrNomePro = astrNomePro;
            this.penmOperador = aenmOperador;
            this.pstrNomeProCom = astrNomeProCom;
        }

        /// <summary>
        /// Identificador exclusivo para propriedade associada a validação
        /// </summary>
        public override object TypeId
        {
            get
            {
                return this.pobjId;
            }
        }

        /// <summary>
        /// Gets Nome da propriedade dependente
        /// </summary>
        /// <value>Valor o do objeto</value>
        public string NomePropDependente
        {
            get { return this.pstrNomePro; }
        }

        /// <summary>
        /// Gets Nome da propriedade a ser comparada
        /// </summary>
        /// <value>Valor o do objeto</value>
        public string NomePropDependenteCom
        {
            get { return this.pstrNomeProCom; }
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
                // Verifica comparação entre propriedades
                bool lbooComPro = this.pstrNomeProCom != null && this.pstrNomeProCom.Trim().Length > 0;
                var lobjPro = aobjContexto.ObjectInstance.GetType().GetProperty(this.pstrNomePro);
                var lobjValPro = lobjPro.GetValue(aobjContexto.ObjectInstance, null);
                var lobjProCom = lbooComPro ? aobjContexto.ObjectInstance.GetType().GetProperty(this.pstrNomeProCom) : null;
                var lobjValProCom = lbooComPro ? lobjProCom.GetValue(aobjContexto.ObjectInstance, null) : null;

                bool lbooResultado = lbooComPro ? this.validarPropDependenteCom(lobjValPro, lobjValProCom) : this.validarPropDependente(lobjValPro);
                if (lbooResultado)
                {
                    return new ValidationResult(string.Format(ErrorMessageString, aobjContexto.DisplayName));
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
            return this.Compare(aobjValPropReal, this.pobjValPropDep, this.penmOperador);
        }

        /// <summary>
        /// VALIDAR A PROPRIEDADE A SER COMPARADA
        /// </summary>
        /// <param name="aobjValPropReal">VALOR DA PROPRIEDADE</param>
        /// <param name="aobjValPropRealCom">VALOR DA PROPRIEDADE COMPARADA</param>
        /// <returns>RESULTADO DA VALIDAÇÃO</returns>
        private bool validarPropDependenteCom(object aobjValPropReal, object aobjValPropRealCom)
        {
            return this.Compare(aobjValPropReal, aobjValPropRealCom, this.penmOperador);
        }

        private bool Compare(object aobjValPropReal, object aobjValPropRealCom, Operador aenmOperador)
        {
            Comparer operador = new Comparer(Globalization.CultureInfo.CurrentCulture);
            int lintResult = 0;

            if (aobjValPropReal != null)
            {
                lintResult = operador.Compare(aobjValPropReal, Convert.ChangeType(aobjValPropRealCom, aobjValPropReal.GetType()));
            }

            switch (aenmOperador)
            {
                case Operador.IsLessTo:
                    return aobjValPropReal == null ? this.pobjValPropDep != null : lintResult < 0;
                case Operador.IsGreaterTo:
                    return aobjValPropReal == null ? this.pobjValPropDep != null : lintResult > 0;
                case Operador.IsLessOrEqualTo:
                    return aobjValPropReal == null ? this.pobjValPropDep != null : lintResult <= 0;
                case Operador.IsGreaterOrEqualTo:
                    return aobjValPropReal == null ? this.pobjValPropDep != null : lintResult >= 0;
                case Operador.IsNotEqualTo:
                    return aobjValPropReal == null ? this.pobjValPropDep != null : lintResult != 0;
                default:
                    return aobjValPropReal == null ? this.pobjValPropDep == null : lintResult == 0;
            }
        }
    }
}