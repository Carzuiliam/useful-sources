using Newtonsoft.Json;
using System;

namespace ViaCEP
{
    public static class CEPSearch
    {

        #region CEP Requests Methods --------------------------------------------------------------

        /// <summary>
        /// Requests info from ViaCEP database, using the given zip code, as the default type (JSON).
        /// </summary>
        /// <param name="_zipcode">The 8-digit zip code value.</param>
        /// <returns>A CEP object with the results.</returns>
        public static CEP ByZipCode(int _zipcode)
        {
            try
            {
                return JsonConvert.DeserializeObject<CEP>(CEPService.RequestInfo(_zipcode, CEPTypes.JSON));
            }
            catch (CEPException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CEPException(ex.Message);
            }
        }

        /// <summary>
        /// Requests info from ViaCEP database, using the given zip code, as a given type.
        /// </summary>
        /// <param name="_zipcode">The 8-digit zip code value.</param>
        /// <param name="_type">The type to search address. Use CEPTypes object to help. Possible values include JSON, XML, PIPED and QUERTY.</param>
        /// <returns>A string with the results (in selected type).</returns>
        /// 
        public static string ByZipCode(int _zipcode, string _type)
        {
            try
            {
                return CEPService.RequestInfo(_zipcode, _type);
            }
            catch (CEPException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CEPException(ex.Message);
            }
        }

        #endregion

    }
}
