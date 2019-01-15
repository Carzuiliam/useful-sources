using System;
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

                string auxCpf = string.Empty;
                string digits = string.Empty;

                int[] factors1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] factors2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                
                _cpf = Format.AsDigitsOnly(_cpf);

                if (_cpf.Length != 11)
                {
                    return false;
                }                    

                auxCpf = _cpf.Substring(0, 9);

                for (int i = 0; i < 9; i++)
                {
                    sum += int.Parse(auxCpf[i].ToString()) * factors1[i];
                }                    

                rest = sum % 11;
                rest = (rest >= 2) ? 11 - rest : 0;

                sum = 0;
                digits += rest;
                auxCpf += digits;
                
                for (int i = 0; i < 10; i++)
                {
                    sum += int.Parse(auxCpf[i].ToString()) * factors2[i];
                }

                rest = sum % 11;
                rest = (rest >= 2) ? 11 - rest : 0;

                digits += rest;

                return _cpf.EndsWith(digits);
            }

            return false;
        }

        #endregion

    }
}
