using System;

namespace Utilities.ViaCEP
{
    /// <summary>
    /// 
    /// </summary>
    public class CEPException : Exception
    {

        #region CEP Exception Messages ------------------------------------------------------------

        /// <summary>
        /// The exception message when a generic exception is thrown.
        /// </summary>
        public static string CEP_EXCEPTION = "An exception were thrown. See the inner exception for details.";

        /// <summary>
        /// The exception message when the zip code is null.
        /// </summary>
        public static string CEP_IS_NULL = "The zip code cannot be null.";

        /// <summary>
        /// The exception message when the ViaCEP Webservice cannot find info about a given CEP.
        /// </summary>
        public static string CEP_NOT_FOUND = "Cannot find any info about the given zip code.";
        
        #endregion

        #region CEP Exception ---------------------------------------------------------------------

        /// <summary>
        /// Just a default Exception implementation for the library.
        /// </summary>
        public CEPException() { }

        /// <summary>
        /// Just a default Exception implementation for the library (with message support).
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public CEPException(string message) : base(message) { }

        /// <summary>
        /// Just a default Exception implementation for the library (with message and inner exception support).
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        /// <param name="inner">The inner exception of this exception.</param>
        public CEPException(string message, Exception inner) : base(message, inner) { }

        #endregion

    }
}