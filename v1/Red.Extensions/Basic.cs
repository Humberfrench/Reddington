using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Red.Extensions
{
    public static class Basic
    {
        public static string ToJSON<T>(this List<T> obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        public static string ToJSON(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        public static T JsonToObject<T>(this string obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return (T)serializer.Deserialize<T>(obj);
        }

        public static string ExceptionTratada(this Exception ex)
        {
            string mensagem = null;
            try
            {
                mensagem = ex.Message.ToString();
            }
            catch (Exception generatedExceptionName)
            {
                return generatedExceptionName.Message;
            }
            return mensagem;
        }

        public static bool IsNumeric(this string text)
        {
            try
            {
                Convert.ToInt32(text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string ToDateFormated(this DateTime dateValue)
        {
            return dateValue.Day.ToString("00") + "/" + dateValue.Month.ToString("00") + "/" + dateValue.Year.ToString("0000");
        }

        public static string ToSimNao(this string stringValue)
        {
            if (stringValue == "S")
            {
                return "Sim";
            }
            return "Não";
        }
        public static string ToSimNao(this bool boolValue)
        {
            if (boolValue)
            {
                return "Sim";
            }
            return "Não";
        }
        public static string ToSimNaoIcone(this bool boolValue)
        {
            if (boolValue)
            {
                return @"<button type='button' class='btn btn-primary btn-sm'>
                        <i class='glyphicon glyphicon-ok-circle'></i>
                        </button>";
            }
            return @"<button type='button' class='btn btn-danger btn-sm'>
                    <i class='glyphicon glyphicon-remove-circle'></i>
                    </button>";
        }
        public static string ToSexo(this string stringValue)
        {
            if (stringValue == "F")
            {
                return "Menina";
            }
            else if (stringValue == "M")
            {
                return "Menino";
            }
            else
            {
                return "Indefinido";
            }
        }

        public static string ToNivel(this string stringValue)
        {
            if (stringValue == "F")
            {
                return "Família";
            }
            else if (stringValue == "C")
            {
                return "Criança";
            }
            else
            {
                return "Todos";
            }
        }

        /// <summary>
        /// transforma a primeira letra e a primeira letra apos white-space em maiuscula, 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static String ToCapitalize(this String text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            var formattedText = new StringBuilder();
            var arWords = text.ToLower().Split(' ');

            foreach (String word in arWords)
            {
                if (word.Trim().Length == 0)
                {
                    continue;
                }

                if (formattedText.Length > 0)
                {
                    formattedText.Append(" ");
                }

                String capLetter = word[0].ToString().ToUpper();

                formattedText.Append(capLetter);

                if (word.Length > 1)
                {
                    formattedText.Append(word.Substring(1));
                }
            }

            return formattedText.ToString();
        }

        /// <summary>
        /// Método para retirar acentos e espaço de uma string.
        /// </summary>
        /// <param name="text">Texto a ser fotrmatado</param>
        /// <returns>Texto sem acento</returns>                    
        public static String RemoveAccent(this String text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            string[] arCharacter = {"á","é","í","ó","ú","à","ã","õ","â","ê","î","ô","û","ä","ë","ï","ö","ü","ç",
                                     "Á","É","Í","Ó","Ú","À","Ã","Õ","Â","Ê","Î","Ô","Û","Ä","Ë","Ï","Ö","Ü","Ç"};

            string[] arNewCharacter = {"a","e","i","o","u","a","a","o","a","e","i","o","u","a","e","i","o","u","c",
                                        "A","E","I","O","U","A","A","O","A","E","I","O","U","A","E","I","O","U","C"};

            for (int i = 0; i < arCharacter.Length; i++)
            {
                text = text.Replace(arCharacter[i], arNewCharacter[i]);
            }

            return text;
        }

        public static String IsValidEmail(this string strIn)
        {
            //Retorna o e-mail quando valido
            var result = Regex.IsMatch(strIn,
                  @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
                  @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");

            return (result) ? strIn : string.Empty;
        }

        /// <summary>
        /// Método para retirar caracteres especiais de uma string
        /// </summary>
        /// <param name="text">Texto a ser fotrmatado</param>
        /// <returns>Texto sem caracteres especiais</returns>                    
        public static String RemoveSpecialCharacter(this String text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            //regex para encontrar qualquer coisa exceto letras, acentuadas, numeros
            Regex rgx = new Regex(@"[^\w]");

            //tudo vira hifen
            string strReturn = rgx.Replace(text, "-");

            //removo hifens repetidos seguidos
            strReturn = strReturn.MergeRepeatedCharacters('-');

            return strReturn;
        }

        public static String MergeRepeatedCharacters(this string text, char repeatedChar)
        {
            var reducedString = Regex.Replace(text, repeatedChar + "+", repeatedChar.ToString());
            var finalString = reducedString.Trim(repeatedChar);

            return finalString;
        }

        public static String ToAlphaNumeric(this String text)
        {
            return text.RemoveAccent().RemoveSpecialCharacter();
        }

        public static string FormatoCpfouCnpj(this string text)
        {
            //CNPJ
            if (text.Length == 14)
                return Convert.ToUInt64(text).ToString(@"00\.000\.000\/0000\-00");

            //CPF
            if (text.Length == 11)
                return Convert.ToUInt64(text).ToString(@"000\.000\.000\-00");

            return text;
        }

        public static bool IsDate(this string date, string format = "dd/MM/yyyy")
        {
            DateTime parsedDate;

            var isValidDate = DateTime.TryParseExact(date, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);

            return isValidDate;
        }

        /// <summary>
        /// converte uma lista de string em uma string separadas por separadores
        /// </summary>
        /// <param name="list">lista</param>
        /// <param name="separator">separador inicial</param>
        /// <param name="lastSeparator">separador do ultimo item</param>
        /// <returns></returns>
        public static string ToGrammarianText(this List<string> list, string separator, string lastSeparator)
        {
            if (list == null || list.Count == 0)
                return string.Empty;

            string format = string.Join("{0}", list.ToArray());

            string result;

            if (list.Count > 2)
                result = string.Format(format.ReplaceLastOccurrence("{0}", "{1}"), separator, lastSeparator);
            else
                result = string.Format(format, lastSeparator);

            return result;
        }

        /// <summary>
        /// converte uma lista de string em uma string separadas por virgula e pela preposicao E
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ToGrammarianText(this List<string> list)
        {
            return list.ToGrammarianText(", ", " e ");
        }

        public static string ToGrammarianText(this IEnumerable<string> list)
        {
            return list.ToList().ToGrammarianText(", ", " e ");
        }

        /// <summary>
        /// replace na ultima ocorrencia somente
        /// </summary>
        /// <param name="text"></param>
        /// <param name="oldString"></param>
        /// <param name="newString"></param>
        /// <returns></returns>
        public static string ReplaceLastOccurrence(this string text, string oldString, string newString)
        {
            int index = text.LastIndexOf(oldString);
            string result = text.Remove(index, oldString.Length).Insert(index, newString);
            return result;
        }

    }
}