using System.Linq;

namespace Utilities.TextFormat
{
    public static class Format
    {

        #region Removing Specific Characters ------------------------------------------------------

        /// <summary>
        /// Returs an string containing only the letetrs of a given string.
        /// </summary>
        /// <param name="_input"></param>
        /// <returns></returns>
        public static string AsLettersOnly(string _input)
        {
            return new string(_input.Where(c => char.IsLetter(c)).ToArray());
        }

        /// <summary>
        /// Returs an string containing only the numbers of a given string.
        /// </summary>
        /// <param name="_input"></param>
        /// <returns></returns>
        public static string AsDigitsOnly(string _input)
        {
            return new string(_input.Where(c => char.IsDigit(c)).ToArray());
        }

        /// <summary>
        /// Returs an string containing only the letters or numbers of a given string.
        /// </summary>
        /// <param name="_input"></param>
        /// <returns></returns>
        public static string AsLettersAndDigitsOnly(string _input)
        {
            return new string(_input.Where(c => char.IsLetterOrDigit(c)).ToArray());
        }

        #endregion

    }
}
