using System;
using System.Net;

namespace CEP
{
    public static class CEPWebService
    {

        #region CEP WebService --------------------------------------------------------------------

        /// <summary>
        /// Builds and does a request for the ViaCEP's webservice in order to get info about a given CEP.
        /// </summary>
        /// <param name="_cep">The CEP to be found.</param>
        /// <returns>A string with the raw data of the results.</returns>
        public static string Request(int _cep)
        {
            try
            {
                string result = string.Empty;
                string viaCEPUrl = string.Empty;

                viaCEPUrl += "https://viacep.com.br/ws/";

                viaCEPUrl += Uri.EscapeUriString(Convert.ToString(_cep));
                viaCEPUrl += "/json/unicode/";

                result = new WebClient().DownloadString(viaCEPUrl);

                return result;
            }
            catch (Exception ex)
            {
                throw new CEPException(ex.Message);
            }
        }

        #endregion

    }
}
