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
        /// <summary>
        /// Analyses the mood of the person bases on the input message
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public string AnalyseMood(string message)
        {
            if (message.Contains("SAD"))
            {
                return "SAD";
            }
            else if (message.Contains("HAPPY"))
            {
                return "HAPPY";
            }
            else
            {
                return "Mood cannot be assessed";
            }
        }
    }
}
