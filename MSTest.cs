using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyse;
namespace MoodAnalyserTest
{
    /// <summary>
    /// MS Testing class
    /// </summary>
    [TestClass]
    public class MSTest
    {
        /// <summary>
        /// Given the happy mood message as parameter should return HAPPY.
        /// </summary>
        [TestMethod]
        public void Given_HappyMoodMessage_Should_Return_HAPPY()
        {
            ///Arrange
            string expected = "HAPPY";
            MoodAnalyser moodAnalyser = new MoodAnalyser("i am very happy".ToUpper());
            ///Act
            string mood = moodAnalyser.AnalyseMood();
            ///Assert
            Assert.AreEqual(expected, mood);
        }
        /// <summary>
        /// Given the sad mood message as parameter should return SAD.
        /// </summary>
        [TestMethod]
        public void Given_SadMoodMessage_Should_Return_SAD()
        {
            ///Arrange
            string expected = "SAD";
            MoodAnalyser moodAnalyser = new MoodAnalyser("i am very sad".ToUpper());
            ///Act
            string mood = moodAnalyser.AnalyseMood();
            ///Assert
            Assert.AreEqual(expected, mood);
        }
        /// <summary>
        /// Given the null as input should return HAPPY.
        /// </summary>
        /// <param name="message">The message.</param>
        [TestMethod]
        [DataRow("null")]///Passed null through DataRow
        public void Given_Null_AsInput_Should_Return_HAPPY(string message)
        {
            //Arrange
            string expected = "HAPPY";
            MoodAnalyser moodAnalyser = new MoodAnalyser(message.ToUpper());
            ///Act
            string mood = moodAnalyser.AnalyseMood();
            ///Assert
            Assert.AreEqual(expected, mood);
        }
    }
}
