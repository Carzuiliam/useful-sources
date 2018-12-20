using Newtonsoft.Json;
using System;

namespace CEP
{
    public static class CEPSearch
    {

        #region CEP Requests Methods --------------------------------------------------------------

        /// <summary>
        /// Requests info from ViaCEP database, using the given zip code, as a JSON object.
        /// </summary>
        /// <param name="_zipcode">The 8-digit zip code ("código CEP") value.</param>
        /// <returns>A CEP object with the query results.</returns>
        public static CEP ByZipCode(int _zipcode)
        {
            try
            {
                return JsonConvert.DeserializeObject<CEP>(CEPWebService.Request(_zipcode));
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
