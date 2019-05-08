using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Utilities.PersonalIDs;

namespace Tests
{
    [TestClass]
    public class Document_Tests
    {

        #region IsValidRG() Method ----------------------------------------------------------------

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

            foreach (var data in dataset)
            {
                var newLine = Environment.NewLine;
                var result = Document.IsValidRG(data);

                var message = string.Format(
                    newLine + "-----------------------------------" +
                    newLine + "| Expected for [" + data + "] --> [True ]." +
                    newLine + "| Obtained for [" + data + "] --> [" + result + "]." +
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

            foreach (var data in dataset)
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

        #region IsValidCPF() Method ---------------------------------------------------------------

        /// <summary>
        /// Tests the 'IsValidCPF' method using cases which must return 'true'.
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

            foreach (var data in dataset)
            {
                var newLine = Environment.NewLine;
                var result = Document.IsValidCPF(data);

                var message = string.Format(
                    newLine + "-----------------------------------" +
                    newLine + "| Expected for [" + data + "] --> [True ]." +
                    newLine + "| Obtained for [" + data + "] --> [" + result + "]." +
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

            foreach (var data in dataset)
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

        #region IsValidCNPJ() Method --------------------------------------------------------------

        /// <summary>
        /// Tests the 'IsValidCNPJ' method using cases which must return 'true'.
        /// </summary>
        [TestMethod]
        public void IsValidCNPJ_ReturnTrue()
        {
            string[] dataset =
            {
                "70.712.730.0001.09",
                "48.438.704.0001-77",
                "57.606.871.0001/70",
                "71.345.033/0001-11",
                "49.314/165/0001-27",
                "52/174/742.0001-37",
                "06-811/172 0001 21",
                "18 999 451 0001 40",
                "62323445 0001 60",
                "93800037000185"
            };

            foreach (var data in dataset)
            {
                var newLine = Environment.NewLine;
                var result = Document.IsValidCNPJ(data);

                var message = string.Format(
                    newLine + "-----------------------------------" +
                    newLine + "| Expected for [" + data + "] --> [True ]." +
                    newLine + "| Obtained for [" + data + "] --> [" + result + "]." +
                    newLine + "-----------------------------------"
                );

                Assert.IsTrue(result, message);
            }
        }

        /// <summary>
        /// Tests the 'IsValidCNPJ' method using cases which must return 'false'.
        /// </summary>
        [TestMethod]
        public void IsValidCNPJ_ReturnFalse()
        {
            string[] dataset =
            {
                "01.961.828/0001-794",  // Valid, but with more digits.
                "06.537.940/0005-09",   // Invalid CNPJ.
                "18.455.241/4001-91",   // Invalid CPF.
                "11.598.430/4321-88",   // Invalid CPF.
                "a2.7b4.f35-e001-d3",   // Letters and numbers.
                "ab.cde.fgh/ijkl-mn",   // Only letters.                
                "@#.%!!.--&/++++-;:",   // Special characters.
                "888.538.890-63",       // Valid, but CPF.
                string.Empty,           // Empty string.
                null                    // Null value.
            };

            foreach (var data in dataset)
            {
                var newLine = Environment.NewLine;
                var result = Document.IsValidCNPJ(data);

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
