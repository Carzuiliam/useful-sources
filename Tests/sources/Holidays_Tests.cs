using Holidays;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class Holidays_Tests
    {
        [TestMethod]
        public void HolidayBRA_ReturnTrue()
        {
            DateTime[] dates =
            {
                new DateTime(2018,  1,  1),     // New Year
                new DateTime(2018,  2, 13),     // Carnival
                new DateTime(2018,  4,  1),     // Easter
                new DateTime(2018,  4, 21),     // Tiradentes
                new DateTime(2018, 11,  2),     // Day of the Dead
                new DateTime(2018, 11, 15),     // Republic's Day
                new DateTime(2018, 12, 25),     // Christmas

                DateTime.MinValue               // 0001-01-01
                
            };

            foreach (DateTime date in dates)
            {
                var result = HolidayBRA.IsHoliday(date);

                Assert.IsTrue(
                    result, 
                    String.Format(Environment.NewLine + "Expected for [{0}]: 'True'." + 
                                  Environment.NewLine + "Obtained: '{1}'.", 
                                  date.ToShortDateString(), result)
                );
            }
        }

        [TestMethod]
        public void HolidayBRA_ReturnFalse()
        {
            DateTime[] dates =
            {
                new DateTime(2018,  1, 31),     // Non-holiday
                new DateTime(2018,  2, 28),     // Non-holiday
                new DateTime(2018,  4, 16),     // Non-holiday
                new DateTime(2018,  5, 18),     // Non-holiday
                new DateTime(2018,  7,  9),     // Non-holiday
                new DateTime(2018, 11, 19),     // Non-holiday
                new DateTime(2018, 12,  1),     // Non-holiday

                DateTime.MaxValue               // 9999-12-31
            };

            foreach (DateTime date in dates)
            {
                var result = HolidayBRA.IsHoliday(date);

                Assert.IsFalse(
                    result,
                    String.Format(Environment.NewLine + "Expected for [{0}]: 'False'." +
                                  Environment.NewLine + "Obtained: '{1}'.",
                                  date.ToShortDateString(), result)
                );
            }
        }
    }
}
