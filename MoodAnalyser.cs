using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyse
{
    /// <summary>
    /// Implementation class
    /// </summary>
    public class MoodAnalyser
    {
        /// Initialised message as private
        private string message;
        /// <summary>
        ///Constructor Initializes a new instance of the <see cref="MoodAnalyser"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        /// <summary>
        /// Analyses the mood of the person bases on the input message
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public string AnalyseMood()
        {
            try
            {
                if (this.message.Contains("SAD"))
                {
                    return "SAD";
                }
                else 
                {
                    return "HAPPY";
                }
            }
            ///Retun HAPPY in case of null exception
            catch
            {
                return "HAPPY";
            }
            
        }
    }
}
