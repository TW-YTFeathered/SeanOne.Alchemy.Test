#define ShowClassAndNamespace
#define ShowResult
#define ShowIsCorrect

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SeanOne.Alchemy.Test
{
    static class TestFactory
    {
        /// <summary>
        /// List of all tests
        /// </summary>
        static List<ITest> Tests = new List<ITest>();

        /// <summary>
        /// Init Tests List
        /// </summary>
        static TestFactory()
        {
            var testTypes = typeof(ITest).Assembly.GetTypes()
                .Where(t => typeof(ITest).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .OrderBy(t => t.Namespace)
                .ThenBy(t => t.Name);

            foreach (var type in testTypes)
            {
                try
                {
                    if (Activator.CreateInstance(type) is ITest test)
                    {
                        Tests.Add(test);
                    }
                }
                catch (Exception ex)
                {
                    Print(ConsoleColor.Yellow, $"Warning: Could not create instance of {type.Name}. {ex.Message}");
                }
            }
        }

        public static int RunCount { get; private set; }
        public static int CorrectCount { get; private set; }
        public static int IncorrectCount { get; private set; }
        public static int ErrorCount { get; private set; }

        /// <summary>
        /// Run all tests
        /// </summary>
        public static void RunTest()
        {
            CorrectCount = 0;
            IncorrectCount = 0;
            ErrorCount = 0;
            RunCount = 0;

            foreach (var test in Tests)
            {
                // Initialize the state for this test run
                bool isCorrect = false;
                bool isError = false;

                var output = new List<string>();
                ConsoleColor color = ConsoleColor.White;

                try
                {
                    test.Setup();

                    // Delay to allow the test to setup
                    Thread.Sleep(200);

#if ShowClassAndNamespace
                    output.Add($"Namespace: {test.GetType().Namespace}");
                    output.Add($"Class: {test.GetType().Name}");
#endif

                    string runResult = test.Run();
                    isCorrect = runResult != null && runResult.Equals(test.GetAnswer());

#if ShowResult
                    output.Add($"Result: {runResult}");
#endif

#if ShowIsCorrect
                    if (isCorrect)
                    {
                        output.Add($"{test.GetType().Name}: Correct");
                        color = ConsoleColor.Green;
                    }
                    else
                    {
                        output.Add($"{test.GetType().Name}: Incorrect");
                        color = ConsoleColor.Red;
                    }
#endif
                }
                catch (Exception ex)
                {
                    isError = true;
                    output.Add($"Error: {ex.Message}");
                    color = ConsoleColor.Red;
                }
                finally
                {
                    if (isError)
                        ErrorCount++;
                    else if (isCorrect)
                        CorrectCount++;
                    else
                        IncorrectCount++;
                    RunCount++;

                    Print(color, output.ToArray());
                }
            }
        }

        /// <summary>
        /// Prints one or more messages to the console, followed by a blank line.
        /// </summary>
        /// <param name="msgs">The messages to print.</param>
        static void Print(params string[] msgs)
        {
            foreach (var m in msgs)
                Console.WriteLine(m);
            Console.WriteLine();
        }

        /// <summary>
        /// Prints one or more messages to the console in the specified color, followed by a blank line.
        /// </summary>
        /// <param name="color">The console text color to use.</param>
        /// <param name="msgs">The messages to print.</param>
        static void Print(ConsoleColor color, params string[] msgs)
        {
            Console.ForegroundColor = color;
            Print(msgs);
            Console.ResetColor();
        }
    }
}
