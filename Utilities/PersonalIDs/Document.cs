using Utilities.TextFormat;

namespace Utilities.PersonalIDs
{
    public class Document
    {

        #region RG's Operations -------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_rg"></param>
        /// <returns></returns>
        public static bool IsValidRG(string _rg)
        {
            if (!string.IsNullOrEmpty(_rg))
            {
                int sum = 0;

                string rg = Format.AsDigitsOnly(_rg);

                int[] factors = new int[9] { 2, 3, 4, 5, 6, 7, 8, 9, 100 };

                if (rg.Length != 9)
                {
                    return false;
                }

                for (int i = 0; i < 9; i++)
                {
                    sum += int.Parse(rg[i].ToString()) * factors[i];
                }

                return (sum % 11) == 0;
            }

            return false;
        }

        #endregion

        #region CPF's Operations ------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_cpf"></param>
        /// <returns></returns>
        public static bool IsValidCPF(string _cpf)
        {
            if (!string.IsNullOrEmpty(_cpf))
            {
                int sum = 0;
                int rest = 0;

                string mainDigits = string.Empty;
                string verifierDigit = string.Empty;
                string cpf = Format.AsDigitsOnly(_cpf);

                int[] factors1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] factors2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                if (_cpf.Length != 11)
                {
                    return false;
                }

                mainDigits = cpf.Substring(0, 9);

                for (int i = 0; i < 9; i++)
                {
                    sum += int.Parse(mainDigits[i].ToString()) * factors1[i];
                }

                rest = ((sum % 11) < 2) ? 0 : 11 - (sum % 11);
                sum = 0;

                verifierDigit = rest.ToString();
                mainDigits = mainDigits + verifierDigit;

                for (int i = 0; i < 10; i++)
                {
                    sum += int.Parse(mainDigits[i].ToString()) * factors2[i];
                }

                rest = ((sum % 11) < 2) ? 0 : 11 - (sum % 11);

                verifierDigit = verifierDigit + rest.ToString();

                return _cpf.EndsWith(verifierDigit);
            }

            return false;
        }

        #endregion

    }
}
