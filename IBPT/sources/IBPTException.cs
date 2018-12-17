using System;

namespace IBPT
{
    class IBPTException : Exception
    {

        #region IBPT Exception --------------------------------------------------------------------

        /// <summary>
        /// Just a default Exception implementation for the library.
        /// </summary>
        public IBPTException() { }

        /// <summary>
        /// Just a default Exception implementation for the library (with message support).
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public IBPTException(string message) : base(message) { }

        /// <summary>
        /// Just a default Exception implementation for the library (with message and inner exception support).
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        /// <param name="inner">The inner exception of this exception.</param>
        public IBPTException(string message, Exception inner) : base(message, inner) { }

        #endregion

    }
}
