using Newtonsoft.Json;
using System;
using System.Text;
using Utilities.TextFormat;

namespace Utilities.ViaCEP
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class CEP
    {

        #region CEP Elements ----------------------------------------------------------------------

        /// <summary>
        /// The CEP's zipcode ("código CEP", as "xxxxx-xxx" format).
        /// </summary>
        [JsonProperty(PropertyName = "cep")]
        public string ZipCode { get; set; } = string.Empty;

        /// <summary>
        /// The CEP's address ("logradouro").
        /// </summary>
        [JsonProperty(PropertyName = "logradouro")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// The CEP's complement ("complemento").
        /// </summary>
        [JsonProperty(PropertyName = "complemento")]
        public string Complement { get; set; } = string.Empty;

        /// <summary>
        /// The CEP's neighborhood ("Bairro").
        /// </summary>
        [JsonProperty(PropertyName = "bairro")]
        public string Neighborhood { get; set; } = string.Empty;

        /// <summary>
        /// The CEP's city ("cidade").
        /// </summary>
        [JsonProperty(PropertyName = "localidade")]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// The CEP's UF ("estado" or "UF", as 2-character format).
        /// </summary>
        [JsonProperty(PropertyName = "uf")]
        public string State { get; set; } = string.Empty;

        /// <summary>
        /// The CEP's unity ("unidade").
        /// </summary>
        [JsonProperty(PropertyName = "unidade")]
        public string Unity { get; set; } = string.Empty;

        /// <summary>
        /// The CEP's IBGE code ("código IBGE").
        /// </summary>
        [JsonProperty(PropertyName = "ibge")]
        public string IBGE { get; set; } = string.Empty;

        /// <summary>
        /// The CEP's GIA code ("código GIA").
        /// </summary>
        [JsonProperty(PropertyName = "gia")]
        public string GIA { get; set; } = string.Empty;

        /// <summary>
        /// The CEP's error code ("código de erro"), if the query fails.
        /// </summary>
        [JsonProperty(PropertyName = "erro")]
        public string Error { get; set; } = string.Empty;

        #endregion

        #region Overrided Methods -----------------------------------------------------------------

        /// <summary>
        /// Verifies if two instances of a CEP are equivalent. This method and the operator == are equivalent.
        /// </summary>
        /// <param name="obj">The CEP object to compare.</param>
        /// <returns>'true' if the instances are equivalent, 'false' otherwise.</returns>
        public override bool Equals(object obj)
        {
            CEP cep = (CEP)obj;

            if (!string.IsNullOrEmpty(ZipCode) && !string.IsNullOrEmpty(cep.ZipCode))
            {
                if (Format.AsDigitsOnly(ZipCode) != Format.AsDigitsOnly(cep.ZipCode)) return false;
            }

            if (!string.IsNullOrEmpty(Address) && !string.IsNullOrEmpty(cep.Address))
            {
                StringBuilder addressA = new StringBuilder(Address.ToLower());
                StringBuilder addressB = new StringBuilder(cep.Address.ToLower());

                addressA.Replace("alameda ", string.Empty);
                addressB.Replace("alameda ", string.Empty);
                addressA.Replace("avenida ", string.Empty);
                addressB.Replace("avenida ", string.Empty);
                addressA.Replace("rua ", string.Empty);
                addressB.Replace("rua ", string.Empty);
                addressA.Replace("travessa ", string.Empty);
                addressB.Replace("travessa ", string.Empty);

                if (addressA.ToString() != addressB.ToString()) return false;
            }

            if (!string.IsNullOrEmpty(Complement) && !string.IsNullOrEmpty(cep.Complement))
            {
                if (Complement != cep.Complement) return false;
            }

            if (!string.IsNullOrEmpty(Neighborhood) && !string.IsNullOrEmpty(cep.Neighborhood))
            {
                StringBuilder neighborhoodA = new StringBuilder(Neighborhood.ToLower());
                StringBuilder neighborhoodB = new StringBuilder(cep.Neighborhood.ToLower());

                neighborhoodA.Replace("bairro ", string.Empty);
                neighborhoodB.Replace("bairro ", string.Empty);
                neighborhoodA.Replace("jardim ", string.Empty);
                neighborhoodB.Replace("jardim ", string.Empty);
                neighborhoodA.Replace("residencial ", string.Empty);
                neighborhoodB.Replace("residencial ", string.Empty);
                neighborhoodA.Replace("vila ", string.Empty);
                neighborhoodB.Replace("vila ", string.Empty);

                if (neighborhoodA.ToString() != neighborhoodB.ToString()) return false;
            }

            if (!string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(cep.City))
            {
                if (City.ToLower() != cep.City.ToLower()) return false;
            }

            if (!string.IsNullOrEmpty(State) && !string.IsNullOrEmpty(cep.State))
            {
                if (State.ToLower() != cep.State.ToLower()) return false;
            }

            if (!string.IsNullOrEmpty(Unity) && !string.IsNullOrEmpty(cep.Unity))
            {
                if (Unity.ToLower() != cep.Unity.ToLower()) return false;
            }

            if (!string.IsNullOrEmpty(IBGE) && !string.IsNullOrEmpty(cep.IBGE))
            {
                if (IBGE != cep.IBGE) return false;
            }

            if (!string.IsNullOrEmpty(GIA) && !string.IsNullOrEmpty(cep.GIA))
            {
                if (GIA != cep.GIA) return false;
            }

            return true;
        }

        /// <summary>
        /// Returns the hash code of the CEP object.
        /// </summary>
        /// <returns>The CEP's hash code.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashcode;

                const int baseHash = 63689;
                const int baseMultiplier = 378551;

                hashcode = (baseHash * baseMultiplier) ^ ZipCode.GetHashCode();
                hashcode = (hashcode * baseMultiplier) ^ Address.GetHashCode();
                hashcode = (hashcode * baseMultiplier) ^ Complement.GetHashCode();
                hashcode = (hashcode * baseMultiplier) ^ Neighborhood.GetHashCode();
                hashcode = (hashcode * baseMultiplier) ^ City.GetHashCode();
                hashcode = (hashcode * baseMultiplier) ^ State.GetHashCode();
                hashcode = (hashcode * baseMultiplier) ^ Unity.GetHashCode();
                hashcode = (hashcode * baseMultiplier) ^ IBGE.GetHashCode();
                hashcode = (hashcode * baseMultiplier) ^ GIA.GetHashCode();

                return hashcode;
            }
        }

        #endregion

        #region Overrided Operators ---------------------------------------------------------------

        /// <summary>
        /// Verifies if two instances of a CEP are equivalent. This operator and the method Equals() are equivalent.
        /// </summary>
        /// <param name="_left">The first CEP object.</param>
        /// <param name="_right">The second CEP object.</param>
        /// <returns>'true' if the instances are equivalent, 'false' otherwise.</returns>
        public static bool operator ==(CEP _left, CEP _right)
        {
            return _left.Equals(_right);
        }

        /// <summary>
        /// Verifies if two instances of a CEP are different.
        /// </summary>
        /// <param name="_left">The first instance.</param>
        /// <param name="_right">The second instance.</param>
        /// <returns>'true' if the instances are different, 'false' otherwise.</returns>
        public static bool operator !=(CEP _left, CEP _right)
        {
            return !_left.Equals(_right);
        }

        #endregion

    }
}
