using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Utilities.PersonalIDs;
using Utilities.TextFormat;

namespace Tests
{
    [TestClass]
    public class Document_Tests
    {

        #region ValidRG() Method ------------------------------------------------------------------

        /// <summary>
        /// Tests the 'IsValidRG' method using cases which must return 'true'.
        /// </summary>
        [TestMethod]
        public void IsValidRG_ReturnTrue()
        {
            string[] dataset =
            {
                "20.129.975.6",
                "17.220.828-2",
                "42.076-332-6",
                "38-467-524-4",
                "31-882-196.5",
                "47-382.507.7",
                "15 862 054.9",
                "39 503 471-1",
                "40166217 2",
                "411144625"
            };

            foreach (string data in dataset)
            {
                var newLine = Environment.NewLine;
                var result = Document.IsValidRG(data);

                var message = string.Format(
                    newLine + "-----------------------------------" +
                    newLine + "| Expected for [" + data + "] --> [True ]." +
                    newLine + "| Obtained for [" + data + "] --> [" + result + " ]." +
                    newLine + "-----------------------------------"
                );

                Assert.IsTrue(result, message);
            }
        }

        /// <summary>
        /// Tests the 'IsValidRG' method using cases which must return 'false'.
        /// </summary>
        [TestMethod]
        public void IsValidRG_ReturnFalse()
        {
            string[] dataset =
            {
                "21-475-758-40",        // Valid, but with more digits.
                "19.542.657-9",         // Invalid RG.
                "47.623.290-0",         // Invalid RG.
                "18.982.994-5",         // Invalid RG;
                "a6.z2y.o28-x",         // Letters and numbers.
                "ab-cde-fgh.i",         // Only letters.     
                "@b.Cd3.#6H.|",         // Special characters.
                "29.996.814-",          // Missing digits.
                string.Empty,           // Empty string.
                null                    // Null value.
            };

            foreach (string data in dataset)
            {
                var newLine = Environment.NewLine;
                var result = Document.IsValidRG(data);

                var message = string.Format(
                    newLine + "-----------------------------------" +
                    newLine + "| Expected for [" + data + "] --> [False]." +
                    newLine + "| Obtained for [" + data + "] --> [" + result + " ]." +
                    newLine + "-----------------------------------"
                );

                Assert.IsFalse(result, message);
            }
        }

        #endregion

        #region ValidCPF() Method -----------------------------------------------------------------

        /// <summary>
        /// Tests the 'IsValidCPF' method using cases which must return 'false'.
        /// </summary>
        [TestMethod]
        public void IsValidCPF_ReturnTrue()
        {
            string[] dataset =
            {
                "412.302.020.80",
                "525.335.230-97",
                "315.027-350-16",
                "984-068-770-06",
                "341-923-970.05",
                "785-738.660.04",
                "402 596 170.91",
                "295 968 000-60",
                "142238430 60",
                "03587071020"
            };

            foreach (string data in dataset)
            {
                var newLine = Environment.NewLine;
                var result = Document.IsValidCPF(data);

                var message = string.Format(
                    newLine + "-----------------------------------" +
                    newLine + "| Expected for [" + data + "] --> [True ]." +
                    newLine + "| Obtained for [" + data + "] --> [" + result + " ]." +
                    newLine + "-----------------------------------"
                );

                Assert.IsTrue(result, message);
            }
        }

        /// <summary>
        /// Tests the 'IsValidCPF' method using cases which must return 'false'.
        /// </summary>
        [TestMethod]
        public void IsValidCPF_ReturnFalse()
        {
            string[] dataset =
            {
                "854-388-290-710",      // Valid, but with more digits.
                "290.748.040-54",       // Invalid CPF.
                "650-010-040.97",       // Invalid CPF.
                "180.470.590-00",       // Invalid CPF.
                "9x3.90y.z80-k9",       // Letters and numbers.
                "abc.def.ghi-jk",       // Only letters.                
                "@bC.d&F.6H|-;K",       // Special characters.
                "508.926.610-7",        // Missing digits.
                string.Empty,           // Empty string.
                null                    // Null value.
            };

            foreach (string data in dataset)
            {
                var newLine = Environment.NewLine;
                var result = Document.IsValidCPF(data);

                var message = string.Format(
                    newLine + "-----------------------------------" +
                    newLine + "| Expected for [" + data + "] --> [False]." +
                    newLine + "| Obtained for [" + data + "] --> [" + result + " ]." +
                    newLine + "-----------------------------------"
                );

                Assert.IsFalse(result, message);
            }
        }

        #endregion

    }
}
