using System;

namespace Utilities.Holidays
{
    /// <summary>
    /// This class realizes operations involving default Brazil's holidays.
    /// </summary>
    public class HolidayBRA : Holiday
    {

        #region Brazilian Holidays' Dates ---------------------------------------------------------

        /// <summary>
        /// The DateTime when the Good Friday's Holiday ("Sexta-feira Santa") will ocurrs in current year.
        /// </summary>
        public static DateTime GoodFriday { get { return GoodFridayFrom(DateTime.Today.Year); } }

        /// <summary>
        /// The DateTime when the Corpus Christi's Holiday ("Corpus Christi") will ocurrs in current year.
        /// </summary>
        public static DateTime CorpusChristi { get { return CorpusChristiFrom(DateTime.Today.Year); } }

        /// <summary>
        /// The DateTime when the Tiradentes' Holiday ("Dia de Tiradentes") will ocurrs in current year.
        /// </summary>
        public static DateTime Tiradentes { get { return TiradentesFrom(DateTime.Today.Year); } }

        /// <summary>
        /// The DateTime when the Worker's Day Holiday ("Dia do Trabalho") will ocurrs in current year.
        /// </summary>
        public static DateTime WorkersDay { get { return WorkersDayFrom(DateTime.Today.Year); } }

        /// <summary>
        /// The DateTime when the Independence's Day Holiday ("Independência") will ocurrs in current year.
        /// </summary>
        public static DateTime IndependenceDay { get { return IndependenceDayFrom(DateTime.Today.Year); } }

        /// <summary>
        /// The DateTime when the Holy Mary's Holiday ("Nossa Senhora Aparecida") will ocurrs in current year.
        /// </summary>
        public static DateTime HolyMary { get { return HolyMaryFrom(DateTime.Today.Year); } }

        /// <summary>
        /// The DateTime when the Day of the Dead's Holiday ("Finados") will ocurrs in current year.
        /// </summary>
        public static DateTime DayOfTheDead { get { return DayOfTheDeadFrom(DateTime.Today.Year); } }

        /// <summary>
        /// The DateTime when the Republic's Holiday ("Proclamação da República") will ocurrs in current year.
        /// </summary>
        public static DateTime RepublicDay { get { return RepublicDayFrom(DateTime.Today.Year); } }

        #endregion

        #region Brazilian Holidays' Calculation ---------------------------------------------------

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
        /// Gets the DateTime when the Corpus Christi's Holiday ("Corpus Christi") will ocurrs in the given year.
        /// </summary>
        /// <param name="_year">The year to be used as reference.</param>
        /// <returns>The DateTime object with the Corpus Christi's Holiday ("Corpus Christi").</returns>
        public static DateTime CorpusChristiFrom(int _year)
        {
            return EasterFrom(_year).AddDays(60);
        }        

        /// <summary>
        /// Gets the DateTime when the Tiradentes' Holiday ("Dia de Tiradentes") will ocurrs in the given year.
        /// </summary>
        /// <param name="_year">The year to be used as reference.</param>
        /// <returns>The DateTime object with the Tiradentes' Holiday ("Dia de Tiradentes").</returns>
        public static DateTime TiradentesFrom(int _year)
        {
            return new DateTime(_year, 4, 21);
        }
        
        /// <summary>
        /// Gets the DateTime when the Worker's Day Holiday ("Dia do Trabalho") will ocurrs in the given year.
        /// </summary>
        /// <param name="_year">The year to be used as reference.</param>
        /// <returns>The DateTime object with the Worker's Day Holiday ("Dia do Trabalho").</returns>
        public static DateTime WorkersDayFrom(int _year)
        {
            return new DateTime(_year, 5, 1);
        }        

        /// <summary>
        /// Gets the DateTime when the Independence's Day Holiday ("Independência") will ocurrs in the given year.
        /// </summary>
        /// <param name="_year">The year to be used as reference.</param>
        /// <returns>The DateTime object with the Independence's Day Holiday ("Independência").</returns>
        public static DateTime IndependenceDayFrom(int _year)
        {
            return new DateTime(_year, 9, 7);
        }        

        /// <summary>
        /// Gets the DateTime when the Holy Mary's Holiday ("Nossa Senhora Aparecida") will ocurrs in the given year.
        /// </summary>
        /// <param name="_year">The year to be used as reference.</param>
        /// <returns>The DateTime object with the Holy Mary's Holiday ("Nossa Senhora Aparecida").</returns>
        public static DateTime HolyMaryFrom(int _year)
        {
            return new DateTime(_year, 10, 12);
        }
        
        /// <summary>
        /// Gets the DateTime when the Day of the Dead's Holiday ("Finados") will ocurrs in the given year.
        /// </summary>
        /// <param name="_year">The year to be used as reference.</param>
        /// <returns>The DateTime object with the Day of the Dead's Holiday ("Finados").</returns>
        public static DateTime DayOfTheDeadFrom(int _year)
        {
            return new DateTime(_year, 11, 2);
        }
        
        /// <summary>
        /// Gets the DateTime when the Republic's Holiday ("Proclamação da República") will ocurrs in the given year.
        /// </summary>
        /// <param name="_year">The year to be used as reference.</param>
        /// <returns>The DateTime object with the Republic's Holiday ("Proclamação da República").</returns>
        public static DateTime RepublicDayFrom(int _year)
        {
            return new DateTime(_year, 11, 15);
        }

        /// <summary>
        /// Verifies if the current day is a Brazil's national holiday.
        /// </summary>
        /// <returns>'true' if the current day is a holiday, 'false' otherwise.</returns>
        public static bool IsHolidayToday()
        {
            return IsHoliday(DateTime.Today);
        }

        /// <summary>
        /// Verifies if the given DateTime is a Brazil's national holiday.
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

            if (_date == CarnivalFrom(_date.Year))
                return true;

            if (_date == CorpusChristiFrom(_date.Year))
                return true;

            if (_date == TiradentesFrom(_date.Year))
                return true;

            if (_date == WorkersDayFrom(_date.Year))
                return true;

            if (_date == IndependenceDayFrom(_date.Year))
                return true;

            if (_date == HolyMaryFrom(_date.Year))
                return true;

            if (_date == DayOfTheDeadFrom(_date.Year))
                return true;

            if (_date == RepublicDayFrom(_date.Year))
                return true;

            if (_date == ChristmasFrom(_date.Year))
                return true;
  
            return false;
        }

        /// <summary>
        /// Verifies if the current day is a Brazil's working day.
        /// </summary>
        /// <returns>'true' if the given day is a working day, 'false' otherwise.</returns>
        public static bool IsWorkingDayToday()
        {
            return IsWorkingDay(DateTime.Today);
        }

        /// <summary>
        /// Verifies if the given DateTime is a Brazil's working day.
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
