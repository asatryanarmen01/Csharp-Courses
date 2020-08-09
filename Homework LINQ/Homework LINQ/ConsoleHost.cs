using Lesson5.Examples;
using Lesson5.Exercise;

namespace Lesson5
{
    /// <summary>
    /// Console host model
    /// </summary>
    public class ConsoleHost
    {
        /// <summary>
        /// Run th application
        /// </summary>
        public void Run()
        {
            // create LINQ examples
            var linqExamples = new LINQExamples();

            //linqExamples.Run();

            // create LINQ exercise
            var linqExercise = new LINQExercise();

            linqExercise.Run();
        }
    }
}