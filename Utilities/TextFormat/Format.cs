using System.Text;
using System.Text.RegularExpressions;

namespace Utilities.TextFormat
{
    public static class Format
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_input"></param>
        /// <returns></returns>
        public static string AsDigitsOnly(string _input)
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (Match match in Regex.Matches(_input, @"\d"))
            {
                sb.Append(match);
            }

            return sb.ToString();
        }

    }
}
