using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyse;
using System;

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
        /// Given the null as input should return mood should not be null
        /// </summary>
        /// <param name="message">The message.</param>
        [TestMethod]
        [DataRow(null)]
        public void Given_Null_AsInput_Should_Return_MOOD_SHOULD_NOT_BE_NULL(string message)
        {
            try
            {
                //Arrange
                MoodAnalyser moodAnalyser = new MoodAnalyser(message);
                ///Act
                var mood = moodAnalyser.AnalyseMood();
            }
            catch (MoodAnalyserCustomException e)
            {
                ///Assert
                Assert.AreEqual("mood should not be null", e.Message);
            }

        }
        /// <summary>
        /// Given Empty message as input parameter should throw exception as
        /// moos should not be empty
        /// </summary>
        [TestMethod]
        public void Given_Empty_AsInput_Should_Return_MOOD_SHOULD_NOT_BE_EMPTY()
        {
            try
            {
                /// Arrange
                string message = "";
                ///string expected = "mood should not be empty";
                MoodAnalyser moodAnalyser = new MoodAnalyser(message);
                ///Act
                var mood = moodAnalyser.AnalyseMood();
            }
            catch (MoodAnalyserCustomException e)
            {
                ///Assert
                Assert.AreEqual("mood should not be empty", e.Message);
            }

        }
        /// <summary>
        /// Given the mood analyse class name should return mood analyse object.
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject()
        {
            object expected = new MoodAnalyser();
            object obj = MoodAnalyseFactory.CreateMoodAnalyserObject("MoodAnalyse.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }
        /// <summary>
        /// Given the mood analyse class name should return mood analyse object.
        /// </summary>
        [TestMethod]
        public void Given_MoodAnalyser_Class_Name_Should_Return_MoodAnalyser_Object()
        {
            //Arrange
            string className = "MoodAnalyse.MoodAnalyser";
            string constructorName = "MoodAnalyser";
            //Act
            object expected = new MoodAnalyser();
            object resultObj = MoodAnalyseFactory.CreateMoodAnalyserObject(className, constructorName);
            //Assert
            expected.Equals(resultObj);
        }
        /// <summary>
        /// Given improper class name should throw exception No such class found
        /// </summary>
        [TestMethod]
        public void Given_Improper_Class_Name_Should_Throw_MoodAnalysisException_Indicating_No_Such_Class()
        {
            try
            {
                //Arrange
                string className = "DemoNamespace.MoodAnalyser";
                string constructorName = "MoodAnalyser";
                //Act
                object resultObj = MoodAnalyseFactory.CreateMoodAnalyserObject(className, constructorName);
            }
            catch (MoodAnalyserCustomException e)
            {
                //Assert
                Assert.AreEqual("class not found", e.Message);
                // string expected = "class not found";
                // expected.Equals(e.Message);
            }
        }
        /// <summary>
        /// Given improper constructor name should throw constructor not found exception
        /// </summary>
        [TestMethod]
        public void Given_Improper_Constructor_Name_Should_Throw_MoodAnalysisException_Indicating_No_Such_Constructor()
        {
            try
            {
                //Arrange
                string className = "MoodAnalyse.MoodAnalyser";
                string constructorName = "SampleConstructorName";
                //Act
                object resultObj = MoodAnalyseFactory.CreateMoodAnalyserObject(className, constructorName);
            }
            catch (MoodAnalyserCustomException e)
            {
                //Assert
                Assert.AreEqual("constructor not found", e.Message);
            }
        }
    }
}
