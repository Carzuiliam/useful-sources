using System;
using System.Net;

namespace IBPT.sources
{
    public static class IBPTWebService
    {
        #region Company Parameters ----------------------------------------------------------------

        /// <summary>
        /// The company's token, which is acquired from the <a href="https://deolhonoimposto.ibpt.org.br/">IBPT site</a>.
        /// </summary>
        private const string COMPANY_TOKEN = "";

        /// <summary>
        /// The company's CNPJ, which is used in combination with the token in order to do requests.
        /// </summary>
        private const string COMPANY_CNPJ = "";

        #endregion

        #region IBPT WebService -------------------------------------------------------------------

        /// <summary>
        /// Builds and does a request to IBPT's webservice in order to get info about a given product.
        /// </summary>
        /// <param name="_ncm">The product's NCM code ("código NCM").</param>
        /// <param name="_state">The product's referee UF ("estado").</param>
        /// <param name="_ex">The product's exception code ("exceção à regra aplicada na NCM").</param>
        /// <param name="_description">The product's description ("descrição").</param>
        /// <param name="_unityMeasure">The product's unity measure ("unidade de medida").</param>
        /// <param name="_value">The product's value ("valor do produto").</param>
        /// <param name="_gtin">The product's GTIN barcode ("código de barras").</param>
        /// <returns>A string with the raw data of the results.</returns>
        public static string Request(string _ncm, string _state, int _ex, string _description, string _unityMeasure, decimal _value, string _gtin)
        {
            try
            {
                string result = string.Empty;
                string ibptUrl = string.Empty;

                ibptUrl += "https://apidoni.ibpt.org.br/api/v1/produtos/";

                ibptUrl += "?token=";
                ibptUrl += Uri.EscapeUriString(COMPANY_TOKEN);
                ibptUrl += "&cnpj=";
                ibptUrl += Uri.EscapeUriString(COMPANY_CNPJ);
                ibptUrl += "&codigo=";
                ibptUrl += Uri.EscapeUriString(_ncm);
                ibptUrl += "&uf=";
                ibptUrl += Uri.EscapeUriString(_state);
                ibptUrl += "&ex=";
                ibptUrl += Uri.EscapeUriString(Convert.ToString(_ex));
                ibptUrl += "&descricao=";
                ibptUrl += Uri.EscapeUriString(_description);
                ibptUrl += "&unidadeMedida=";
                ibptUrl += Uri.EscapeUriString(_unityMeasure);
                ibptUrl += "&valor=";
                ibptUrl += Uri.EscapeUriString(Convert.ToString(_value));
                ibptUrl += "&gtin=";
                ibptUrl += Uri.EscapeUriString(_gtin);

                result = new WebClient().DownloadString(ibptUrl);

                return result;
            }
            catch (Exception ex)
            {
                throw new IBPTException(ex.Message);
            }
        }

        /// <summary>
        /// Builds and does a request to IBPT's webservice in order to get info about a given service.
        /// </summary>
        /// <param name="_ncm">The service's NCM code ("código NCM").</param>
        /// <param name="_state">The service's referee UF ("estado").</param>
        /// <param name="_description">The service's description ("descrição").</param>
        /// <param name="_unityMeasure">The service's unity measure ("unidade de medida").</param>
        /// <param name="_value">The service's value ("valor do produto").</param>
        /// <param name="_gtin">The service's GTIN barcode ("código de barras").</param>
        /// <returns>A string with the raw data of the results.</returns>
        public static string Request(string _ncm, string _state, string _description, string _unityMeasure, decimal _value, string _gtin)
        {
            try
            {
                string result = string.Empty;
                string ibptUrl = string.Empty;

                ibptUrl += $"https://apidoni.ibpt.org.br/api/v1/servicos/";

                ibptUrl += "?token=";
                ibptUrl += COMPANY_TOKEN;
                ibptUrl += "&cnpj=";
                ibptUrl += COMPANY_CNPJ;
                ibptUrl += "&codigo=";
                ibptUrl += _ncm;
                ibptUrl += "&uf=";
                ibptUrl += _state;
                ibptUrl += "&descricao=";
                ibptUrl += _description;
                ibptUrl += "&unidadeMedida=";
                ibptUrl += _unityMeasure;
                ibptUrl += "&valor=";
                ibptUrl += _value;
                ibptUrl += "&gtin=";
                ibptUrl += _gtin;

                result = new WebClient().DownloadString(ibptUrl);

                return result;
            }
            catch (Exception ex)
            {
                throw new IBPTException(ex.Message);
            }
        }

        #endregion

    }
}
