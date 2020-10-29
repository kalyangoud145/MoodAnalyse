using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserTest
{
    /// <summary>
    /// Class for implementing cutomised exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class MoodAnalyserCustomException : Exception
    {
        ///declaring enum variables for different type of expections 
        public enum ExceptionType
        {
            NULL_MESSAGE, EMPTY_MESSAGE, NO_SUCH_FIELD, NO_SUCH_METHOD, NO_SUCH_CLASS, OBJECT_CREATION_ISSUE
        }
        /// <summary>
        ///Declaring ExceptionType object as type
        /// </summary>
        readonly ExceptionType type;
        /// <summary>
        /// constructor Initializes a new instance of the <see cref="MoodAnalyserCustomException"/> 
        /// class.
        /// </summary>
        /// <param name="Type">The type.</param>
        /// <param name="message">The message.</param>
        public MoodAnalyserCustomException(ExceptionType Type, string message) : base(message)
        {
            this.type = Type;
        }

    }
}
