using Newtonsoft.Json;
using System;

namespace IBPT
{
    [Serializable]
    public class IBPTProduct
    {

        #region Product Elements ------------------------------------------------------------------

        /// <summary>
        /// The product's NCM code ("código NCM").
        /// </summary>
        [JsonProperty(PropertyName = "Codigo")]
        public string Code { get; set; }

        /// <summary>
        ///The product's UF ("estado").
        /// </summary>
        [JsonProperty(PropertyName = "UF")]
        public string UF { get; set; }

        /// <summary>
        ///The product's description ("descrição").
        /// </summary>
        [JsonProperty(PropertyName = "Descricao")]
        public string Description { get; set; }

        /// <summary>
        /// The product's type ("tipo").
        /// </summary>
        [JsonProperty(PropertyName = "Tipo")]
        public string Type { get; set; }

        /// <summary>
        /// The product's initial valid date ("data inicial de vigência").
        /// </summary>
        [JsonProperty(PropertyName = "VigenciaInicio")]
        public string ValidSince { get; set; }

        /// <summary>
        /// The product's final valid date ("data final de vigência").
        /// </summary>
        [JsonProperty(PropertyName = "VigenciaFim")]
        public string ValidUntil { get; set; }

        /// <summary>
        /// The product's key ("chave").
        /// </summary>
        [JsonProperty(PropertyName = "Chave")]
        public string Key { get; set; }

        /// <summary>
        /// The IBPT's version ("versão").
        /// </summary>
        [JsonProperty(PropertyName = "Versao")]
        public string Version { get; set; }

        /// <summary>
        /// The product's source ("fonte").
        /// </summary>
        [JsonProperty(PropertyName = "Fonte")]
        public string Source { get; set; }

        /// <summary>
        /// The product's EX code ("exceção à regra aplicada na NCM").
        /// </summary>
        [JsonProperty(PropertyName = "EX")]
        public int EX { get; set; }

        /// <summary>
        /// The product's country tax ("taxa nacional").
        /// </summary>
        [JsonProperty(PropertyName = "Nacional")]
        public decimal CountryTax { get; set; }

        /// <summary>
        /// The product's state tax ("taxa estadual").
        /// </summary>
        [JsonProperty(PropertyName = "Estadual")]
        public decimal StateTax { get; set; }

        /// <summary>
        /// The product's city tax ("taxa municipal").
        /// </summary>
        [JsonProperty(PropertyName = "Municipal")]
        public decimal CityTax { get; set; }

        /// <summary>
        /// The product's international tax ("taxa internacional").
        /// </summary>
        [JsonProperty(PropertyName = "Importado")]
        public decimal ImportedTax { get; set; }

        #endregion

    }
}
