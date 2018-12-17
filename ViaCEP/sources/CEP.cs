using Newtonsoft.Json;
using System;

namespace ViaCEP
{
    [Serializable]
    public class CEP
    {

        #region CEP Elements ----------------------------------------------------------------------

        /// <summary>
        /// The CEP's zipcode ("código CEP", as "xxxxx-xxx" format).
        /// </summary>
        [JsonProperty(PropertyName = "cep")]
        public string ZipCode { get; set; }

        /// <summary>
        /// The CEP's address ("logradouro").
        /// </summary>
        [JsonProperty(PropertyName = "logradouro")]
        public string Address { get; set; }

        /// <summary>
        /// The CEP's complement ("complemento").
        /// </summary>
        [JsonProperty(PropertyName = "complemento")]
        public string Complement { get; set; }

        /// <summary>
        /// The CEP's neighborhood ("Bairro").
        /// </summary>
        [JsonProperty(PropertyName = "bairro")]
        public string Neighborhood { get; set; }

        /// <summary>
        /// The CEP's city ("cidade").
        /// </summary>
        [JsonProperty(PropertyName = "localidade")]
        public string City { get; set; }

        /// <summary>
        /// The CEP's UF ("estado" or "UF", as 2-character format).
        /// </summary>
        [JsonProperty(PropertyName = "uf")]
        public string State { get; set; }

        /// <summary>
        /// The CEP's unity ("unidade").
        /// </summary>
        [JsonProperty(PropertyName = "unidade")]
        public string Unity { get; set; }

        /// <summary>
        /// The CEP's IBGE code ("código IBGE").
        /// </summary>
        [JsonProperty(PropertyName = "ibge")]
        public string IBGE { get; set; }

        /// <summary>
        /// The CEP's GIA code ("código GIA").
        /// </summary>
        [JsonProperty(PropertyName = "gia")]
        public string GIA { get; set; }

        #endregion

    }
}
