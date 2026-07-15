#define ShowClassAndNamespace
#define ShowResult
#define ShowIsCorrect

namespace SeanOne.Alchemy.Test
{
    static class TestFactory
    {
        /// <summary>
        /// List of all tests
        /// </summary>
        static List<ITest> Tests = new();

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

        /// <summary>
        /// Run all tests
        /// </summary>
        public static void RunTest()
        {
            foreach (var test in Tests)
            {
                List<string> output = new();
                ConsoleColor color = ConsoleColor.White;

                try
                {
                    test.Setup();

                    // Delay to allow the test to setup
                    Task.Delay(200).Wait();

#if ShowClassAndNamespace
                    output.AddRange($"Namespace: {test.GetType().Namespace}", $"Class: {test.GetType().Name}");
#endif
#if ShowResult
                    string msg = test.Run();
                    output.Add($"Result: {msg}");
#endif
#if ShowIsCorrect
                    bool isCorrect = test.Run().Equals(test.GetAnswer());

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
                    output.Add($"Error: {ex.Message}");
                    color = ConsoleColor.Red;
                }
                finally
                {
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
