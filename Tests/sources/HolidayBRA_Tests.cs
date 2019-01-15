using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Utilities.Holidays;

namespace Tests
{
    [TestClass]
    public class HolidayBRA_Tests
    {

        #region IsHoliday() Method ----------------------------------------------------------------

        /// <summary>
        /// Tests the 'IsHoliday' method using cases which must return 'true'.
        /// </summary>
        [TestMethod]
        public void IsHoliday_ReturnTrue()
        {
            DateTime[] dataset =
            {
                new DateTime(2017, 02, 28),     // Carnival (2017).
                new DateTime(2017, 04, 16),     // Easter (2017).
                new DateTime(2017, 06, 15),     // Corpus Christi (2017).
                new DateTime(2018, 01, 01),     // New Year (2018).           
                new DateTime(2019, 03, 05),     // Carnival (2019).                
                new DateTime(2018, 04, 01),     // Easter (2018).
                new DateTime(2018, 04, 21),     // Tiradentes (2018).           
                new DateTime(2018, 05, 31),     // Corpus Christi (2018).
                new DateTime(2018, 12, 25),     // Christmas (2018).
                new DateTime(),                 // 01/01/0001.
                DateTime.MinValue               // 01/01/0001.
            };

            foreach (DateTime data in dataset)
            {
                var newLine = Environment.NewLine;
                var result = HolidayBRA.IsHoliday(data);

                var message = string.Format(
                    newLine + "-----------------------------------" +
                    newLine + "| Expected for [" + data.ToShortDateString() + "] --> [True]." + 
                    newLine + "| Obtained for [" + data.ToShortDateString() + "] --> [" + result + " ]." +
                    newLine + "-----------------------------------"
                );

                Assert.IsTrue(result, message);
            }
        }

        /// <summary>
        /// Tests the 'IsHoliday' method using cases which must return 'false'.
        /// </summary>
        [TestMethod]
        public void IsHoliday_ReturnFalse()
        {
            DateTime[] dataset =
            {
                new DateTime(2018, 01, 31),     // Non-holiday (commom).
                new DateTime(2018, 02, 28),     // Non-holiday (was 2017 Carnival).
                new DateTime(2018, 04, 16),     // Non-holiday (was 2017 Easter).
                new DateTime(2018, 06, 15),     // non-holiday (was 2017 Corpus Christi).
                new DateTime(2018, 07, 09),     // Non-holiday (only Sao Paulo's state holiday).
                new DateTime(2018, 07, 15),     // Non-holiday (commom).
                new DateTime(2018, 08, 31),     // Non-holiday (commom).
                new DateTime(2018, 11, 19),     // Non-holiday (city holiday).
                new DateTime(2018, 11, 30),     // Non-holiday (commom).
                DateTime.MaxValue               // 31/12/9999.
            };

            foreach (DateTime data in dataset)
            {
                var newLine = Environment.NewLine;
                var result = HolidayBRA.IsHoliday(data);

                var message = string.Format(
                    newLine + "-----------------------------------" +
                    newLine + "| Expected for [" + data.ToShortDateString() + "] --> [False]." +
                    newLine + "| Obtained for [" + data.ToShortDateString() + "] --> [" + result + " ]." +
                    newLine + "-----------------------------------"
                );

                Assert.IsFalse(result, message);
            }
        }

        #endregion

        #region IsWorkingDay() Method -------------------------------------------------------------

        /// <summary>
        /// Tests the 'IsWorkingDay' method using cases which must return 'true'.
        /// </summary>
        [TestMethod]
        public void IsWorkingDay_ReturnTrue()
        {
            DateTime[] dataset =
            {
                new DateTime(2018, 01, 31),     // Non-holiday (commom).
                new DateTime(2018, 02, 28),     // Non-holiday (was 2017 Carnival).
                new DateTime(2018, 04, 16),     // Non-holiday (was 2017 Easter).
                new DateTime(2018, 06, 15),     // non-holiday (was 2017 Corpus Christi).
                new DateTime(2018, 07, 09),     // Non-holiday (only Sao Paulo's state holiday).
                new DateTime(2018, 07, 16),     // Non-holiday (commom).
                new DateTime(2018, 08, 31),     // Non-holiday (commom).
                new DateTime(2018, 11, 19),     // Non-holiday (city holiday).
                new DateTime(2018, 11, 30),     // Non-holiday (commom).
                DateTime.MaxValue               // 31/12/9999.
            };

            foreach (DateTime data in dataset)
            {
                var newLine = Environment.NewLine;
                var result = HolidayBRA.IsWorkingDay(data);

                var message = string.Format(
                    newLine + "-----------------------------------" +
                    newLine + "| Expected for [" + data.ToShortDateString() + "] --> [True]." +
                    newLine + "| Obtained for [" + data.ToShortDateString() + "] --> [" + result + " ]." +
                    newLine + "-----------------------------------"
                );

                Assert.IsTrue(result, message);
            }
        }

        /// <summary>
        /// Tests the 'IsWorkingDay' method using cases which must return 'false'.
        /// </summary>
        [TestMethod]
        public void IsWorkingDay_ReturnFalse()
        {
            DateTime[] dataset =
            {
                new DateTime(2017, 06, 10),     // A saturday.
                new DateTime(2017, 06, 10),     // A sunday.
                new DateTime(2017, 02, 28),     // Carnival (2017).
                new DateTime(2017, 04, 16),     // Easter (2017).
                new DateTime(2017, 06, 15),     // Corpus Christi (2017).
                new DateTime(2019, 03, 05),     // Carnival (2019).                
                new DateTime(2018, 04, 01),     // Easter (2018).
                new DateTime(2018, 04, 21),     // Tiradentes (2018).
                new DateTime(2018, 12, 25),     // Christmas (2018).
                new DateTime(),                 // 01/01/0001.
                DateTime.MinValue               // 01/01/0001.
            };

            foreach (DateTime data in dataset)
            {
                var newLine = Environment.NewLine;
                var result = HolidayBRA.IsWorkingDay(data);

                var message = string.Format(
                    newLine + "-----------------------------------" +
                    newLine + "| Expected for [" + data.ToShortDateString() + "] --> [False]." +
                    newLine + "| Obtained for [" + data.ToShortDateString() + "] --> [" + result + " ]." +
                    newLine + "-----------------------------------"
                );

                Assert.IsFalse(result, message);
            }
        }

        #endregion

    }
}
