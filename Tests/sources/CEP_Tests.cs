using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Utilities.ViaCEP;

namespace Tests
{
    [TestClass]
    public class CEP_Tests
    {

        #region CEPSearch Method ------------------------------------------------------------------

        /// <summary>
        /// Tests the 'CEPSearch' method using cases which must return 'true'.
        /// </summary>
        [TestMethod]
        public void CEPSearch_ReturnTrue()
        {
            var dataset = new List<CEP>()
            {
                // Fully address.
                new CEP()
                {
                    ZipCode = "03102-000",
                    Address = "Avenida Alcântara Machado",
                    Complement = "até 600 - lado par",
                    Neighborhood = "Brás",
                    City = "São Paulo",
                    State = "SP",
                    Unity = "(vazio)",
                    IBGE = "3550308",
                    GIA = "1004"
                },

                // Without "Unity".
                new CEP()
                {
                    ZipCode = "90030-140",
                    Address = "Avenida Alberto Bins",
                    Complement = "até 714 - lado par",
                    Neighborhood = "Centro Histórico",
                    City = "Porto Alegre",
                    State = "RS",
                    IBGE = "4314902",
                    GIA = "(vazio)"
                },

                // Without "Unity" and "GIA".
                new CEP()
                {
                    ZipCode = "40010-905",
                    Address = "Avenida Estados Unidos",
                    Complement = "45",
                    Neighborhood = "Comércio",
                    City = "Salvador",
                    State = "BA",
                    IBGE = "2927408"
                },

                // Without "Complement", "Unity" and "GIA".
                new CEP()
                {
                    ZipCode = "60060-095",
                    Address = "Praça Abrahão de Carvalho",
                    Neighborhood = "Centro",
                    City = "Fortaleza",
                    State = "CE",
                    IBGE = "2304400"
                },                

                // Without "Complement", "Neighborhood", "Unity" and "GIA".
                new CEP()
                {
                    ZipCode = "79002-933",
                    Address = "Avenida Afonso Pena",
                    City = "Campo Grande",
                    State = "MS",
                    IBGE = "5002704"
                },

                // Only "ZipCode", "Address", "City" and "State".
                new CEP()
                {
                    ZipCode = "69005-140",
                    Address = "Avenida 7 de Setembro",
                    City = "Manaus",
                    State = "AM"
                },
                
                // Only "ZipCode", "City" and "State", no '-' on "ZipCode".
                new CEP()
                {
                    ZipCode = "19400-000",
                    City = "Presidente Venceslau",
                    State = "SP"
                },

                // Only "ZipCode", "City" and "State", space on "ZipCode".
                new CEP()
                {
                    ZipCode = "19360 000",
                    City = "Santo Anastácio",
                    State = "SP"
                }
            };

            foreach (CEP data in dataset)
            {
                var newLine = Environment.NewLine;
                var result = CEPSearch.ByZipCode(data.ZipCode);

                var message = string.Format(
                    newLine +
                    newLine + "-----------------------------------" +
                    newLine + "| Expected for [" + data.ZipCode + "] --> [True]" +
                    newLine + "|" + 
                    newLine + "| - " + data.Address +
                    newLine + "| - " + data.Complement +
                    newLine + "| - " + data.Neighborhood +
                    newLine + "| - " + data.City +
                    newLine + "| - " + data.State +
                    newLine + "| - " + data.Unity +
                    newLine + "| - " + data.IBGE +
                    newLine + "| - " + data.GIA +
                    newLine + "|" +
                    newLine + "| Obtained for [" + data.ZipCode + "] --> [False]" +
                    newLine + "| - " + result.Address +
                    newLine + "| - " + result.Complement +
                    newLine + "| - " + result.Neighborhood +
                    newLine + "| - " + result.City +
                    newLine + "| - " + result.State +
                    newLine + "| - " + result.Unity +
                    newLine + "| - " + result.IBGE +
                    newLine + "| - " + result.GIA,
                    newLine + "-----------------------------------"
                );

                Assert.IsTrue(data.Equals(result), message);
            }
        }

        /// <summary>
        /// Tests the 'CEPSearch' method using cases which must return 'false'.
        /// </summary>
        [TestMethod]
        public void CEPSearch_ReturnFalse()
        {
            var dataset = new List<CEP>()
            {
                // Fully address, wrong "Complement" ("251").
                new CEP()
                {
                    ZipCode = "50010-905",
                    Address = "Rua Siqueira Campos",
                    Complement = "250", 
                    Neighborhood = "Santo Antônio",
                    City = "Recife",
                    State = "PE",
                    Unity = "",
                    IBGE = "2611606",
                    GIA = "(vazio)"
                },

                // Without "Unity", wrong "Address" ("Rua Campos Salles").
                new CEP()
                {
                    ZipCode = "19020-730",
                    Address = "Avenida Alberto Bins",
                    Complement = "(vazio)",
                    Neighborhood = "Vila Santa Izabel",
                    City = "Presidente Prudente",
                    State = "SP",
                    IBGE = "3541406",
                    GIA = "5629"
                },

                // Without "Unity" and "GIA", wrong "Neighborhood" ("Penha").
                new CEP()
                {
                    ZipCode = "21020-190",
                    Address = "Rua Conde de Agrolongo",
                    Complement = "(vazio)",
                    Neighborhood = "Baile do Denis",
                    City = "Rio de Janeiro",
                    State = "RJ",
                    IBGE = "3304557"
                },

                // Without "Complement", "Unity" and "GIA", wrong "City" ("Fortaleza").
                new CEP()
                {
                    ZipCode = "60020-190",
                    Address = "Rua Caio Carlos",
                    Neighborhood = "Benfica",
                    City = "Imperatriz",
                    State = "CE",
                    IBGE = "2304400"
                },

                // Without "Complement", "Neighborhood", "Unity" and "GIA", wrong "State" ("DF").
                new CEP()
                {
                    ZipCode = "70100-000",
                    Address = "Praça dos Três Poderes",
                    City = "Brasília",
                    State = "GO",
                    IBGE = "5300108"
                },

                // Only "ZipCode", "Address", "City", "State" and "IBGE", wrong "IBGE" ("1302603").
                new CEP()
                {
                    ZipCode = "69005-140",
                    Address = "Avenida 7 de Setembro",
                    City = "Manaus",
                    State = "AM",
                    IBGE = "100001"
                },
                
                // Only "ZipCode", "City" and "State", wrong "City" and "State" ("Santo Anastácio", "SP").
                new CEP()
                {
                    ZipCode = "19360-000",
                    City = "Ribeirão dos Índios",
                    State = "PR"
                },

                // Only "ZipCode", "City" and "State", wrong "City" and "State" ("Santo Anastácio", "SP").
                new CEP()
                {
                    ZipCode = "19400-000",
                    City = "Nazareno",
                    State = "MG"
                }
            };

            foreach (CEP data in dataset)
            {
                var newLine = Environment.NewLine;
                var result = CEPSearch.ByZipCode(data.ZipCode);

                var message = string.Format(
                    newLine +
                    newLine + "-----------------------------------" +
                    newLine + "| Expected for [" + data.ZipCode + "] --> [False]" +
                    newLine + "|" +
                    newLine + "| - " + data.Address +
                    newLine + "| - " + data.Complement +
                    newLine + "| - " + data.Neighborhood +
                    newLine + "| - " + data.City +
                    newLine + "| - " + data.State +
                    newLine + "| - " + data.Unity +
                    newLine + "| - " + data.IBGE +
                    newLine + "| - " + data.GIA +
                    newLine + "|" +
                    newLine + "| Obtained for [" + data.ZipCode + "] --> [True]" +
                    newLine + "| - " + result.Address +
                    newLine + "| - " + result.Complement +
                    newLine + "| - " + result.Neighborhood +
                    newLine + "| - " + result.City +
                    newLine + "| - " + result.State +
                    newLine + "| - " + result.Unity +
                    newLine + "| - " + result.IBGE +
                    newLine + "| - " + result.GIA,
                    newLine + "-----------------------------------",
                    data.ZipCode
                );

                Assert.IsFalse(data == result, message);
            }
        }

        /// <summary>
        /// Tests the 'CEPSearch' method using cases that must throws exceptions.
        /// </summary>
        [TestMethod]
        public void CEPSearch_ThrowException()
        {
            var dataset = new List<CEP>()
            {                
                new CEP() { ZipCode = "00000-000" },    // Unknown CEP.
                new CEP() { ZipCode = "abcde-fgh" },    // Broken CEP format.
                new CEP() { ZipCode = "@bcd3-fgH" },    // Broken CEP format #2.
                new CEP() { ZipCode = "00000000" },     // Empty CEP.
                new CEP() { ZipCode = "19360-00" },     // Missing digit.
                new CEP() { ZipCode = "1936000" },      // Missing digit #2.
                new CEP() { ZipCode = null },           // Null zipcode.
                new CEP(),                              // Empty CEP.
            };

            foreach (CEP data in dataset)
            {
                try
                {
                    var result = CEPSearch.ByZipCode(data.ZipCode);
                }
                catch (CEPException)
                {
                    Assert.IsTrue(true); continue;
                }
                catch (Exception)
                {
                    Assert.Fail();
                }

                Assert.Fail();
            }
        }

        #endregion

    }
}
