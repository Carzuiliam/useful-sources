using Newtonsoft.Json;
using System;

namespace IBPT.sources
{
    public static class IBPTSearch
    {

        #region IBPT Requests Methods -------------------------------------------------------------

        /// <summary>
        /// Requests info for a product, from IBPT database, using the given parameters, as a JSON object.
        /// </summary>
        /// <param name="_ncm">The product's NCM code ("código NCM").</param>
        /// <param name="_state">The product's referee UF ("estado").</param>
        /// <param name="_ex">The product's exception code ("exceção à regra aplicada na NCM").</param>
        /// <param name="_description">The product's description ("descrição").</param>
        /// <param name="_unityMeasure">The product's unity measure ("unidade de medida").</param>
        /// <param name="_value">The product's value ("valor do produto").</param>
        /// <param name="_gtin">The product's GTIN barcode ("código de barras").</param>
        /// <returns>An IBPT object with the query results.</returns>
        public static IBPT ByProductCode(string _ncm, string _state, int _ex, string _description, string _unityMeasure, decimal _value, string _gtin)
        {
            try
            {
                return JsonConvert.DeserializeObject<IBPT>(IBPTWebService.Request(_ncm, _state, _ex, _description, _unityMeasure, _value, _gtin));
            }
            catch (IBPTException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new IBPTException(ex.Message);
            }
        }

        /// <summary>
        /// Requests info for a service, from IBPT database, using the given parameters, as a JSON object.
        /// </summary>
        /// <param name="_ncm">The service's NCM code ("código NCM").</param>
        /// <param name="_state">The service's referee UF ("estado").</param>
        /// <param name="_description">The service's description ("descrição").</param>
        /// <param name="_unityMeasure">The service's unity measure ("unidade de medida").</param>
        /// <param name="_value">The service's value ("valor do produto").</param>
        /// <param name="_gtin">The service's GTIN barcode ("código de barras").</param>
        /// <returns>An IBPT object with the query results.</returns>
        public static IBPT ByServiceCode(string _ncm, string _state, string _description, string _unityMeasure, decimal _value, string _gtin)
        {
            try
            {
                return JsonConvert.DeserializeObject<IBPT>(IBPTWebService.Request(_ncm, _state, _description, _unityMeasure, _value, _gtin));
            }
            catch (IBPTException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new IBPTException(ex.Message);
            }
        }

        #endregion

    }
}
