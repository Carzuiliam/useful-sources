using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Utilities.PersonalIDs;

namespace Tests
{
    [TestClass]
    public class Document_Tests
    {

        #region ValidRG Method --------------------------------------------------------------------

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
                    newLine + "| Expected for [" + data + "] --> [True]." +
                    newLine + "| Obtained for [" + data + "] --> [" + result + " ]." +
                    newLine + "-----------------------------------"
                );

                Assert.IsTrue(result, message);
            }
        }

        #endregion

        #region ValidCPF Method -------------------------------------------------------------------

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
                "9x3.90y.z80-k9",       // Letters and numbers.
                "abc.def.ghi-jk",       // Only letters.
                "180.470.590-09",       // Invalid CPF, no separators.
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
