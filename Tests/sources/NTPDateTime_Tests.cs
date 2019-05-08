using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Utilities.Holidays;
using Utilities.WindowsNTP;

namespace Tests
{
    [TestClass]
    public class NTPDateTime_Tests
    {

        #region FromWindowsServers() Method -------------------------------------------------------

        /// <summary>
        /// Tests the 'FromWindowsServers' method using cases which must return 'true'.
        /// </summary>
        [TestMethod]
        public void NTPDateTime_AreEqual()
        {
            DateTime data = DateTime.Now;
            DateTime result = NTPDateTime.FromWindowsServers();

            data = new DateTime(data.Year, data.Month, data.Day, data.Hour, data.Minute, 0);
            result = new DateTime(result.Year, result.Month, result.Day, result.Hour, result.Minute, 0);

            var newLine = Environment.NewLine;

            var message = string.Format(
                    newLine +
                    newLine + "-----------------------------------" +
                    newLine + "| Expected for [" + data.ToString() + "] --> [True]" +
                    newLine + "|" +
                    newLine + "| - " + data.Year +
                    newLine + "| - " + data.Month +
                    newLine + "| - " + data.Day +
                    newLine + "| - " + data.Hour +
                    newLine + "| - " + data.Minute +
                    newLine + "|" +
                    newLine + "| Obtained for [" + data.ToString() + "] --> [False]" +
                    newLine + "| - " + result.Year +
                    newLine + "| - " + result.Month +
                    newLine + "| - " + result.Day +
                    newLine + "| - " + result.Hour +
                    newLine + "| - " + result.Minute +
                    newLine + "-----------------------------------"
                );

            Assert.AreEqual(data, result, message);
        }

        /// <summary>
        ///  Tests the 'FromWindowsServers' method using cases that must throws exceptions.
        /// </summary>
        [TestMethod]
        public void NTPDateTime_ThrowException()
        {
            try
            {
                var result = NTPDateTime.FromServerURL(string.Empty);
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
                return;
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
                return;
            }

            Assert.Fail();
        }

        #endregion

    }
}
