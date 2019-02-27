using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Utilities.ViaCEP;

namespace Tests
{
    [TestClass]
    public class ViaCEP_Tests
    {

        #region CEPSearch Method ------------------------------------------------------------------

        /// <summary>
        ///  Tests the 'CEPSearch' method using cases that must match. Note that the CEP's can match
        /// even if detailed info are missing.
        /// </summary>
        [TestMethod]
        public void CEPSearch_AreEqual()
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

            foreach (var data in dataset)
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

                Assert.AreEqual(result, data, message);
            }
        }

        /// <summary>
        ///  Tests the 'CEPSearch' method using cases that must throws exceptions.
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

            foreach (var data in dataset)
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
