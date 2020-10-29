using System;

namespace MoodAnalyse
{
    /// <summary>
    /// Main class for implementation
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main class for implementing problem
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser();
            Console.WriteLine("The person is in " + moodAnalyser.AnalyseMood("he is very happy".ToUpper() )+ " Mood");
        }
    }
}
