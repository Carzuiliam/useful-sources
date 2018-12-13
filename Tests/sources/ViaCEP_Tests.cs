using ViaCEP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class ViaCEP_Tests
    {

        [TestMethod]
        public void CEPSearch_ReturnTrue()
        {
            var dataset = new List<KeyValuePair<int, string>>()
            {
               new KeyValuePair<int, string>(19360000, "Santo Anastácio"),      // Santo Anastácio (SP) 
               new KeyValuePair<int, string>(19020730, "Presidente Prudente")   // Pres. Prudente (SP) 
            };

            foreach (KeyValuePair<int, string> data in dataset)
            {
                var newLine = Environment.NewLine;
                var result = CEPSearch.ByZipCode(data.Key).City;

                var message = String.Format(
                    newLine + "Expected for [{0}]: '" + data.Value + "'." +
                    newLine + "Obtained for [{0}]: '{1}'.",
                    data.Key, result
                );

                Assert.AreEqual(data.Value, result, message);
            }
        }

    }
}
