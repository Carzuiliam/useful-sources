using Holidays;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class HolidayBRA_Tests
    {
        [TestMethod]
        public void HolidayBRA_ReturnTrue()
        {
            DateTime[] dataset =
            {
                new DateTime(2017, 02, 28),     // Carnival (2017)
                new DateTime(2017, 04, 16),     // Easter (2017)
                new DateTime(2017, 06, 15),     // Corpus Christi (2017)
                new DateTime(2018, 01, 01),     // New Year (2018)                
                new DateTime(2019, 03, 05),     // Carnival (2019)                
                new DateTime(2018, 04, 01),     // Easter (2018)
                new DateTime(2018, 04, 21),     // Tiradentes (2018)                
                new DateTime(2018, 05, 31),     // Corpus Christi (2018)
                new DateTime(2018, 11, 02),     // Day of the Dead (2018)
                new DateTime(2018, 11, 15),     // Republic's Day (2018)
                new DateTime(2018, 12, 25)      // Christmas (2018)
            };

            foreach (DateTime data in dataset)
            {
                var newLine = Environment.NewLine;
                var result = HolidayBRA.IsHoliday(data);

                var message = string.Format(
                    newLine +
                    newLine + "Expected for [{0}] --> [True]." + 
                    newLine + "Obtained for [{0}] --> [{1}]." +
                    newLine, 
                    data.ToShortDateString(), result
                );

                Assert.IsTrue(result, message);
            }
        }

        [TestMethod]
        public void HolidayBRA_ReturnFalse()
        {
            DateTime[] dataset =
            {
                new DateTime(2018, 01, 31),     // Non-holiday (commom)
                new DateTime(2018, 02, 28),     // Non-holiday (was 2017 Carnival)
                new DateTime(2018, 04, 16),     // Non-holiday (was 2017 Easter)
                new DateTime(2018, 06, 15),     // non-holiday (was 2017 Corpus Christi)
                new DateTime(2018, 07, 09),     // Non-holiday (Only Sao Paulo's state holiday)
                new DateTime(2018, 07, 15),     // Non-holiday (commom)
                new DateTime(2018, 08, 31),     // Non-holiday (commom)
                new DateTime(2018, 11, 19),     // Non-holiday (city holiday)
                new DateTime(2018, 11, 30),     // Non-holiday (commom)
                new DateTime(2018, 12, 31)      // Non-holiday (post-Christmas)
            };

            foreach (DateTime data in dataset)
            {
                var newLine = Environment.NewLine;
                var result = HolidayBRA.IsHoliday(data);

                var message = string.Format(
                    newLine +
                    newLine + "Expected for [{0}] --> [False]." +
                    newLine + "Obtained for [{0}] --> [{1}]." +
                    newLine,
                    data.ToShortDateString(), result
                );

                Assert.IsFalse(result, message);
            }
        }

        [TestMethod]
        public void HolidayBRA_CriticalCases()
        {
            var dataset = new List<KeyValuePair<DateTime, bool>>()
            {
                new KeyValuePair<DateTime, bool>(DateTime.MinValue,  true),     // Min. date (01/01/0001)
                new KeyValuePair<DateTime, bool>(DateTime.MaxValue, false),     // Max. date (31/12/9999)
                new KeyValuePair<DateTime, bool>(new DateTime(),     true)      // Date: 01/01/0001
            };

            foreach (KeyValuePair<DateTime, bool> data in dataset)
            {
                var newLine = Environment.NewLine;
                var result = HolidayBRA.IsHoliday(data.Key);

                var message = string.Format(
                    newLine +
                    newLine + "Expected for [{0}] --> [" + data + "]" +
                    newLine + "Obtained for [{0}] --> [{1}]" +
                    newLine,
                    data.Key.ToShortDateString(), result
                );

                Assert.AreEqual(data.Value, result, message);
            }
        }
    }
}
