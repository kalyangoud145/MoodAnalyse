using MoodAnalyserTest;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyse
{
    /// <summary>
    /// class for implementing reflection for mood analyser
    /// </summary>
    public class MoodAnalyseFactory
    {
        /// <summary>
        /// Creates the mood analyser object.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructorName">Name of the constructor.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">
        /// class not found.
        /// or
        /// constructor not found.
        /// </exception>
        public static object CreateMoodAnalyserObject(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "class not found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "constructor not found");
            }
        }
        /// <summary>
        /// Creates the mood analyser using parameterized constructor.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructorName">Name of the constructor.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalysisException">
        /// constructor is not found.
        /// or
        /// class not found.
        /// </exception>
        public static object CreateMoodAnalyserUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                    object instance = constructorInfo.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "constructor not found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "class not found");
            }
        }
        /// <summary>
        /// Invokes the analyse mood.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">no such method.</exception>
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyse.MoodAnalyser");
                object moodAnalyserObj = MoodAnalyseFactory.CreateMoodAnalyserUsingParameterizedConstructor("MoodAnalyse.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object mood = methodInfo.Invoke(moodAnalyserObj, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "no such method");
            }
        }
        /// <summary>
        /// Sets the field value to change the mood dynamically
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalysisCustomException">
        /// No such field found
        /// or
        /// Mood should not be NULL
        /// </exception>
        public static Object SetFieldValue(string message, string fieldName)
        {
            // Get the type of the class
            Type type = typeof(MoodAnalyser);

            // Create an object of class
            object mood = Activator.CreateInstance(type);

            //Get the field and If the field is not found it throws null exception and if message is empty throw exception
            // catch the exception if thrown
            try
            {
                // Get the field by using reflections
                FieldInfo fieldInfo = type.GetField(fieldName);

                // set the field value of a particular field in particular object
                fieldInfo.SetValue(mood, message);

                // Get the method using reflection
                MethodInfo method = type.GetMethod("AnalyseMood");

                // Invoke the method using reflection
                object methodReturn = method.Invoke(mood, null);
                return methodReturn;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_FIELD, "No such field found");
            }
            catch
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NULL_MESSAGE, "Mood should not be NULL");
            }
        }
    }
}

