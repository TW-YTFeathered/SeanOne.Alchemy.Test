namespace SeanOne.Alchemy.Test
{
    public interface ITest
    {
        /// <summary>
        /// Performs setup operations required before running the test.
        /// </summary>
        void Setup();

        /// <summary>
        /// Executes the test logic and returns the result.
        /// </summary>
        /// <returns>
        /// A string representing the outcome of the test execution.
        /// </returns>
        string Run();

        /// <summary>
        /// Gets the correct answer for the test.
        /// </summary>
        /// <returns>
        /// The correct answer as a string.
        /// </returns>
        string GetAnswer();
    }
}