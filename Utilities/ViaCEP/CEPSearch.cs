using Newtonsoft.Json;
using System;
using System.Net;
using Utilities.TextFormat;

namespace Utilities.ViaCEP
{
    /// <summary>
    /// This class searches info about a given CEP, querying the ViaCEP webservice.
    /// </summary>
    public static class CEPSearch
    {

        #region CEP Requests Methods --------------------------------------------------------------

        /// <summary>
        /// Requests info from ViaCEP database, using the given zip code, as a JSON object.
        /// </summary>
        /// <param name="_zipcode">The 8-digit zip code ("código CEP") value.</param>
        /// <returns>A CEPInfo object with the query results.</returns>
        public static CEP ByZipCode(string _zipcode)
        {
            try
            {
                if (_zipcode != null)
                {
                    CEP cep = null;

                    string viaCEPUrl = string.Empty;
                    string webClient = string.Empty;

                    viaCEPUrl += "https://viacep.com.br/ws/";
                    viaCEPUrl += Uri.EscapeUriString(Format.AsDigitsOnly(_zipcode));
                    viaCEPUrl += "/json/unicode/";

                    webClient = new WebClient().DownloadString(viaCEPUrl);

                    cep = JsonConvert.DeserializeObject<CEP>(webClient);

                    if (string.IsNullOrEmpty(cep.Error))
                    {
                        return cep;
                    }
                    else
                    {
                        throw new CEPException(CEPException.CEP_NOT_FOUND);
                    }
                }
                else
                {
                    throw new CEPException(CEPException.CEP_IS_NULL);
                }                               
            }
            catch (CEPException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CEPException(CEPException.CEP_EXCEPTION, ex);
            }
        }

        #endregion

    }
}
