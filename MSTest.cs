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
            MoodAnalyser moodAnalyser = new MoodAnalyser();
            ///Act
            string mood = moodAnalyser.AnalyseMood("i am very happy".ToUpper());
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
            MoodAnalyser moodAnalyser = new MoodAnalyser();
            ///Act
            string mood = moodAnalyser.AnalyseMood("i am very sad".ToUpper());
            ///Assert
            Assert.AreEqual(expected, mood);
        }
    }
}
