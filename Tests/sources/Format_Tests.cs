using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Utilities.TextFormat;

namespace Tests
{
    [TestClass]
    public class Format_Tests
    {

        #region AsLettersOnly() Method ------------------------------------------------------------

        /// <summary>
        /// Tests the 'AsLettersOnly' method using cases that must match.
        /// </summary>
        [TestMethod]
        public void AsLettersOnly_AreEqual()
        {
            KeyValuePair<string, string>[] dataset =
            {
                new KeyValuePair<string, string>("abcdefghij", "abcdefghij"),                   // Lower letters
                new KeyValuePair<string, string>("WpuKmIcOTc", "WpuKmIcOTc"),                   // Upper and lower letters
                new KeyValuePair<string, string>("Xs3Xu9pgkz", "XsXupgkz"),                     // With numbers
                new KeyValuePair<string, string>("JM;xk.laeP", "JMxklaeP"),                     // With special chars
                new KeyValuePair<string, string>("&}}KqTl@;C5", "KqTlC"),                       // With numbers and special characters
                new KeyValuePair<string, string>("@u?1e\nLEbj", "ueLEbj"),                      // With numbers, special chars and escapes
                new KeyValuePair<string, string>("CXI-4208", "CXI"),                            // Vehicle plate
                new KeyValuePair<string, string>("12345", string.Empty),                        // Only numbers
                new KeyValuePair<string, string>("cD", "cD"),                                   // Lower and upper letters
                new KeyValuePair<string, string>("", string.Empty),                             // Empty text
                new KeyValuePair<string, string>("a", "a"),                                     // Lower letter
                new KeyValuePair<string, string>("B", "B"),                                     // Upper letter
                new KeyValuePair<string, string>("0", string.Empty),                            // Only numbers
                new KeyValuePair<string, string>("!", string.Empty),                            // Special characters
                new KeyValuePair<string, string>(string.Empty, string.Empty),                   // Empty text
                new KeyValuePair<string, string>(Environment.NewLine, string.Empty),            // Special characters               
            };

            foreach (var data in dataset)
            {
                var newLine = Environment.NewLine;
                var result = Format.AsLettersOnly(data.Key);

                var message = string.Format(
                    newLine + "-----------------------------------" +
                    newLine + "| Expected for [" + data.Key + "] --> [" + data.Value + "]." +
                    newLine + "| Obtained for [" + data.Key + "] --> [" + result + "]." +
                    newLine + "-----------------------------------"
                );

                Assert.AreEqual(result, data.Value, message);
            }
        }

        #endregion

        #region AsDigitsOnly() Method -------------------------------------------------------------

        /// <summary>
        /// Tests the 'AsDigitsOnly' method using cases that must match.
        /// </summary>
        [TestMethod]
        public void AsDigitsOnly_AreEqual()
        {
            KeyValuePair<string, string>[] dataset =
            {
                new KeyValuePair<string, string>("123456789012345", "123456789012345"),         // All numbers
                new KeyValuePair<string, string>("484.53081.92-9", "48453081929"),              // PIS/PASEP
                new KeyValuePair<string, string>("586.679.570-11", "58667957011"),              // CPF
                new KeyValuePair<string, string>("10.148.817-8", "101488178"),                  // RG
                new KeyValuePair<string, string>("19360-000", "19360000"),                      // CEP
                new KeyValuePair<string, string>("CXI-4208", "4208"),                           // Vehicle plate
                new KeyValuePair<string, string>("@u?1e\nLEbj", "1"),                           // With letetrs, special chars and escapes
                new KeyValuePair<string, string>("!1@2#3$4%5{{6", "123456"),                    // Garbage
                new KeyValuePair<string, string>("ABCDE", string.Empty),                        // Only text
                new KeyValuePair<string, string>("\n", string.Empty),                           // Escapes
                new KeyValuePair<string, string>("", string.Empty),                             // Empty text
                new KeyValuePair<string, string>("1", "1"),                                     // Single number
                new KeyValuePair<string, string>("A", string.Empty),                            // Only numbers
                new KeyValuePair<string, string>("?", string.Empty),                            // Special characters
                new KeyValuePair<string, string>(string.Empty, string.Empty),                   // Empty text
                new KeyValuePair<string, string>(Environment.NewLine, string.Empty)             // Special characters 
            };

            foreach (var data in dataset)
            {
                var newLine = Environment.NewLine;
                var result = Format.AsDigitsOnly(data.Key);

                var message = string.Format(
                    newLine + "-----------------------------------" +
                    newLine + "| Expected for [" + data.Key + "] --> [" + data.Value + "]." +
                    newLine + "| Obtained for [" + data.Key + "] --> [" + result + "]." +
                    newLine + "-----------------------------------"
                );

                Assert.AreEqual(result, data.Value, message);
            }
        }

        #endregion

    }
}
