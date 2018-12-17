using System;
using System.Net;

namespace ViaCEP
{
    public static class CEPService
    {

        #region ViaCEP Service --------------------------------------------------------------------

        /// <summary>
        /// Do a request for the ViaCEP webservice in order to get info about a given CEP.
        /// </summary>
        /// <param name="_cep">The CEP to be found.</param>
        /// <param name="_type">The format type of the query. Use CEPTypes object to help. Possible values include JSON, XML, PIPED and QUERTY.</param>
        /// <returns></returns>
        public static string RequestInfo(int _cep, string _type)
        {
            try
            {
                string result = string.Empty;
                string viaCEPUrl = $"https://viacep.com.br/ws/{_cep}/{_type}/unicode/";

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
