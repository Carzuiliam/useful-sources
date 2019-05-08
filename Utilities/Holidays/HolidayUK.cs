using System;

namespace Utilities.Holidays
{
    /// <summary>
    /// This class realizes operations involving default UK's holidays.
    /// </summary>
    public class HolidayUK : Holiday
    {

        #region United Kingdom Holidays' Dates ----------------------------------------------------

        /// <summary>
        /// The DateTime when the Good Friday's Holiday ("Sexta-feira Santa") will ocurrs in current year.
        /// </summary>
        public static DateTime GoodFriday { get { return GoodFridayFrom(DateTime.Today.Year); } }

        /// <summary>
        /// The DateTime when the Good Friday's Holiday ("Segunda-feira Santa") will ocurrs in current year.
        /// </summary>
        public static DateTime EasterMonday { get { return EasterMondayFrom(DateTime.Today.Year); } }

        /// <summary>
        /// The DateTime when the Early May's Holiday ("Dia do Trabalhador") will ocurrs in current year.
        /// </summary>
        public static DateTime EarlyMayBank { get { return EarlyMayBankFrom(DateTime.Today.Year); } }

        /// <summary>
        /// The DateTime when the Spring's Holiday ("Feriado de Primavera") will ocurrs in current year.
        /// </summary>
        public static DateTime SpringBank { get { return SpringBankFrom(DateTime.Today.Year); } }

        /// <summary>
        /// The DateTime when the Summer's Holiday ("Feriado de Primavera") will ocurrs in current year.
        /// </summary>
        public static DateTime SummerBank { get { return SummerBankFrom(DateTime.Today.Year); } }

        /// <summary>
        /// The DateTime when the Boxing Day's Holiday ("Pós-Natal") will ocurrs in current year.
        /// </summary>
        public static DateTime BoxingDay { get { return BoxingDayFrom(DateTime.Today.Year); } }

        #endregion

        #region United Kingdom Holidays' Calculation ----------------------------------------------

        /// <summary>
        /// Gets the DateTime when the Good Friday's Holiday ("Sexta-feira Santa") will ocurrs in the given year.
        /// </summary>
        /// <param name="_year">The year to be used as reference.</param>
        /// <returns>The DateTime object with the Good Friday's Holiday ("Sexta-feira Santa").</returns>
        public static DateTime GoodFridayFrom(int _year)
        {
            return EasterFrom(_year).AddDays(-2);
        }

        /// <summary>
        /// Gets the DateTime when the Easter Monday's Holiday ("Segunda-feira Santa") will ocurrs in the given year.
        /// </summary>
        /// <param name="_year">The year to be used as reference.</param>
        /// <returns>The DateTime object with the Easter Monday's Holiday ("Segunda-feira Santa").</returns>
        public static DateTime EasterMondayFrom(int _year)
        {
            return EasterFrom(_year).AddDays(1);
        }

        /// <summary>
        /// Gets the DateTime when the Early May Bank's Holiday ("Dia do Trabalhador") will ocurrs in the given year.
        /// </summary>
        /// <param name="_year">The year to be used as reference.</param>
        /// <returns>The DateTime object with the Early May Bank's Holiday ("Dia do Trabalhador").</returns>
        public static DateTime EarlyMayBankFrom(int _year)
        {
            DateTime earlyMay = new DateTime(_year, 5, 1);

            while (earlyMay.DayOfWeek != DayOfWeek.Monday)
            {
                earlyMay = earlyMay.AddDays(1);
            }

            return earlyMay;
        }

        /// <summary>
        /// Gets the DateTime when the Spring Bank's Holiday ("Feriado de Primavera") will ocurrs in the given year.
        /// </summary>
        /// <param name="_year">The year to be used as reference.</param>
        /// <returns>The DateTime object with the Spring Bank's Holiday ("Feriado de Primavera").</returns>
        public static DateTime SpringBankFrom(int _year)
        {
            DateTime springBank = new DateTime(_year, 5, 31);

            while (springBank.DayOfWeek != DayOfWeek.Monday)
            {
                springBank = springBank.AddDays(-1);
            }

            return springBank;
        }

        /// <summary>
        /// Gets the DateTime when the Summer Bank's Holiday ("Feriado de Verão") will ocurrs in the given year.
        /// </summary>
        /// <param name="_year">The year to be used as reference.</param>
        /// <returns>The DateTime object with the Spring Bank's Holiday ("Feriado de Primavera").</returns>
        public static DateTime SummerBankFrom(int _year)
        {
            DateTime summerBank = new DateTime(_year, 8, 31);

            while (summerBank.DayOfWeek != DayOfWeek.Monday)
            {
                summerBank = summerBank.AddDays(-1);
            }

            return summerBank;
        }

        /// <summary>
        /// Gets the DateTime when the Boxing Day's Holiday ("Pós-Natal") will ocurrs in the given year.
        /// </summary>
        /// <param name="_year">The year to be used as reference.</param>
        /// <returns>The DateTime object with the Boxing Day's Holiday ("Pós-Natal").</returns>
        public static DateTime BoxingDayFrom(int _year)
        {
            return new DateTime(_year, 12, 26);
        }

        /// <summary>
        /// Verifies if the current day is a UK's national holiday.
        /// </summary>
        /// <returns>'true' if the current day is a holiday, 'false' otherwise.</returns>
        public static bool IsHolidayToday()
        {
            return IsHoliday(DateTime.Today);
        }

        /// <summary>
        /// Verifies if the given DateTime is a UK's national holiday.
        /// </summary>
        /// <param name="_date">The date to be analyzed.</param>
        /// <returns>'true' if the given day is a holiday, 'false' otherwise.</returns>
        public static bool IsHoliday(DateTime _date)
        {
            _date = _date.Date;

            if (_date == NewYearFrom(_date.Year))
                return true;

            if (_date == GoodFridayFrom(_date.Year))
                return true;

            if (_date == EasterFrom(_date.Year))
                return true;

            if (_date == EasterMondayFrom(_date.Year))
                return true;

            if (_date == CarnivalFrom(_date.Year))
                return true;

            if (_date == EarlyMayBankFrom(_date.Year))
                return true;

            if (_date == SpringBankFrom(_date.Year))
                return true;

            if (_date == SummerBankFrom(_date.Year))
                return true;

            if (_date == ChristmasFrom(_date.Year))
                return true;

            if (_date == BoxingDayFrom(_date.Year))
                return true;

            return false;
        }

        /// <summary>
        /// Verifies if the current day is a UK's working day.
        /// </summary>
        /// <returns>'true' if the given day is a working day, 'false' otherwise.</returns>
        public static bool IsWorkingDayToday()
        {
            return IsWorkingDay(DateTime.Today);
        }

        /// <summary>
        /// Verifies if the given DateTime is a UK's working day.
        /// </summary>
        /// <param name="_date"></param>
        /// <returns>'true' if the given day is a working day, 'false' otherwise.</returns>
        public static bool IsWorkingDay(DateTime _date)
        {
            return
                !(_date.DayOfWeek == DayOfWeek.Saturday) &&
                !(_date.DayOfWeek == DayOfWeek.Sunday) &&
                !IsHoliday(_date);
        }

        #endregion

    }
}
