namespace ErrorHandlerApplication.ErrorHandlingTasks
{
    /// <summary>
    /// InvalidUserInputException class is the custom exception class which inherits Exception class.
    /// </summary>
    internal class InvalidUserInputException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUserInputException"/> class.
        /// </summary>
        public InvalidUserInputException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUserInputException"/> class.
        /// </summary>
        /// <param name="message">Message is the exception message that is passed.</param>
        public InvalidUserInputException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUserInputException"/> class.
        /// </summary>
        /// <param name="message">Message is the exception message</param>
        /// <param name="innerException">innerException is the type of exception that is passed on.</param>
        public InvalidUserInputException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
