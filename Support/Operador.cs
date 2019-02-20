// ----------------------------------------------------------------------
// <copyright file="Operador.cs" company="Banco do Nordeste S.A">
//     Copyright © Banco do Nordeste S.A 2011
// </copyright>
// <summary>CLASSE Operador EM UTILS</summary>
// ------------------------------------------------------------------------
namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// ENUME DE OPERAÇÕES
    /// </summary>
    public enum Operador
    {
        /// <summary>
        /// É IGUAL QUE ==
        /// </summary>
        IsEqualTo,

        /// <summary>
        /// NÃO É IGUAL QUE !=
        /// </summary>
        IsNotEqualTo,

        /// <summary>
        /// MENOR OU IGUAL QUE
        /// </summary>
        IsLessOrEqualTo,

        /// <summary>
        /// MAIOR OU IGUAL QUE >=
        /// </summary>
        IsGreaterOrEqualTo,

        /// <summary>
        /// INDICADOR SE MENOR QUE
        /// </summary>
        IsLessTo,

        /// <summary>
        /// MAIOR QUE >
        /// </summary>
        IsGreaterTo
    }
}