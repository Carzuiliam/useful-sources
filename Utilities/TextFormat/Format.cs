using System.Linq;

namespace Utilities.TextFormat
{
    /// <summary>
    /// This class formats any input string to a desired output type.
    /// </summary>
    public static class Format
    {

        #region Removing Specific Characters ------------------------------------------------------

        /// <summary>
        /// Returs an string containing only the letetrs of the input string.
        /// </summary>
        /// <param name="_input"></param>
        /// <returns></returns>
        public static string AsLettersOnly(string _input)
        {
            return new string(_input.Where(c => char.IsLetter(c)).ToArray());
        }

        /// <summary>
        /// Returs an string containing only the numbers of the input string.
        /// </summary>
        /// <param name="_input"></param>
        /// <returns></returns>
        public static string AsDigitsOnly(string _input)
        {
            return new string(_input.Where(c => char.IsDigit(c)).ToArray());
        }

        /// <summary>
        /// Returs an string containing only the letters or numbers of the input string.
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
