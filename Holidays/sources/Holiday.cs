using System;

namespace Holidays
{
    /// <summary>
    /// This class realizes operations involving commom holidays from the Gregorian calendar.
    /// </summary>
    public abstract class Holiday
    {

        #region Common Holidays' Dates ------------------------------------------------------------

        /// <summary>
        /// The DateTime when the New Year's Holiday ("Ano Novo") will ocurrs in current year.
        /// </summary>
        public static DateTime NewYear { get { return NewYearFrom(DateTime.Today.Year); } }

        /// <summary>
        /// The DateTime when the Easter's Holiday ("Domingo de Páscoa") will ocurrs in current year.
        /// </summary>
        public static DateTime Easter { get { return EasterFrom(DateTime.Today.Year); } }

        /// <summary>
        /// The DateTime when the Carnival ("Carnaval") will ocurrs in current year.
        /// </summary>
        public static DateTime Carnival { get { return CarnivalFrom(DateTime.Today.Year); } }

        /// <summary>
        /// The DateTime when the Christmas' Holiday ("Natal") will ocurrs in current year.
        /// </summary>
        public static DateTime Christmas { get { return ChristmasFrom(DateTime.Today.Year); } }

        #endregion

        #region Commom Holidays' Calculation ------------------------------------------------------

        /// <summary>
        /// Gets the DateTime when the New Year's Holiday ("Ano Novo") will ocurrs in the given year.
        /// </summary>
        /// <param name="_year">The year to be used as reference.</param>
        /// <returns>The DateTime object with the New Year's Holiday ("Ano Novo").</returns>
        public static DateTime NewYearFrom(int _year)
        {
            return new DateTime(_year, 1, 1);
        }

        /// <summary>
        /// Gets the DateTime when the Easter's Holiday ("Domingo de Páscoa") will ocurrs in the given year.
        /// </summary>
        /// <param name="_year">The year to be used as reference.</param>
        /// <returns>The DateTime object with the Easter's Holiday ("Páscoa").</returns>
        public static DateTime EasterFrom(int _year)
        {
            DateTime easter;

            int a = _year % 19;
            int b = _year % 4;
            int c = _year % 7;
            int d = (19 * a + 24) % 30;
            int e = (2 * b + 4 * c + 6 * d + 5) % 7;

            if ((d + e) > 9)
            {
                easter = new DateTime(_year, 4, (d + e - 9));
            }
            else
            {
                easter = new DateTime(_year, 3, (d + e + 22));
            }

            if (easter.Month == 4)
            {
                if (easter.Day == 26)
                {
                    easter = new DateTime(_year, 4, 19);
                }
                else if ((easter.Day == 25) && (a > 10) && (d == 28))
                {
                    easter = new DateTime(_year, 4, 18);
                }
            }

            return easter;
        }

        /// <summary>
        /// Gets the DateTime when the Carnival ("Carnaval") will ocurrs in the given year.
        /// </summary>
        /// <param name="_year">The year to be used as reference.</param>
        /// <returns>The DateTime object with the Carnival's Holiday ("Carnaval").</returns>
        public static DateTime CarnivalFrom(int _year)
        {
            return EasterFrom(_year).AddDays(-47);
        }


        /// <summary>
        /// Gets the DateTime when the Christmas' Holiday ("Natal") will ocurrs in the given year.
        /// </summary>
        /// <param name="_year">The year to be used as reference.</param>
        /// <returns>The DateTime object with the Christmas' Holiday ("Natal").</returns>
        public static DateTime ChristmasFrom(int _year)
        {
            return new DateTime(_year, 12, 25);
        }

        #endregion

    }
}
