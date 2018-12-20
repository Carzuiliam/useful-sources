using Newtonsoft.Json;
using System;

namespace IBPT
{
    [Serializable]
    public class IBPT
    {

        #region Product/Service Elements ----------------------------------------------------------

        /// <summary>
        /// The product's (or service's) NCM code ("código NCM").
        /// </summary>
        [JsonProperty(PropertyName = "Codigo")]
        public string Code { get; set; }

        /// <summary>
        /// The product's (or service's) referee UF ("estado").
        /// </summary>
        [JsonProperty(PropertyName = "UF")]
        public string UF { get; set; }

        /// <summary>
        /// The product's (or service's) description ("descrição").
        /// </summary>
        [JsonProperty(PropertyName = "Descricao")]
        public string Description { get; set; }

        /// <summary>
        /// The product's (or service's) type ("tipo").
        /// </summary>
        [JsonProperty(PropertyName = "Tipo")]
        public string Type { get; set; }

        /// <summary>
        /// The product's (or service's) initial valid date ("data inicial de vigência").
        /// </summary>
        [JsonProperty(PropertyName = "VigenciaInicio")]
        public string ValidSince { get; set; }

        /// <summary>
        /// The product's (or service's) final valid date ("data final de vigência").
        /// </summary>
        [JsonProperty(PropertyName = "VigenciaFim")]
        public string ValidUntil { get; set; }

        /// <summary>
        /// The product's (or service's) key ("chave").
        /// </summary>
        [JsonProperty(PropertyName = "Chave")]
        public string Key { get; set; }

        /// <summary>
        /// The IBPT's (or service's) version ("versão").
        /// </summary>
        [JsonProperty(PropertyName = "Versao")]
        public string Version { get; set; }

        /// <summary>
        /// The product's (or service's) source ("fonte").
        /// </summary>
        [JsonProperty(PropertyName = "Fonte")]
        public string Source { get; set; }

        /// <summary>
        /// The product's (or service's) exception code ("exceção à regra aplicada na NCM").
        /// </summary>
        [JsonProperty(PropertyName = "EX")]
        public int EX { get; set; }

        /// <summary>
        /// The product's (or service's) country tax ("taxa nacional").
        /// </summary>
        [JsonProperty(PropertyName = "Nacional")]
        public decimal CountryTax { get; set; }

        /// <summary>
        /// The product's (or service's) state tax ("taxa estadual").
        /// </summary>
        [JsonProperty(PropertyName = "Estadual")]
        public decimal StateTax { get; set; }

        /// <summary>
        /// The product's (or service's) city tax ("taxa municipal").
        /// </summary>
        [JsonProperty(PropertyName = "Municipal")]
        public decimal CityTax { get; set; }

        /// <summary>
        /// The product's (or service's) international tax ("taxa internacional").
        /// </summary>
        [JsonProperty(PropertyName = "Importado")]
        public decimal ImportedTax { get; set; }

        #endregion

    }
}
