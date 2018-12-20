using System;

namespace CEP
{
    public class CEPException : Exception
    {

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