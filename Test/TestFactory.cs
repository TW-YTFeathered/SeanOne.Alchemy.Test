//#define ShowClassAndNamespace

#if ShowClassAndNamespace
// 如果有定義 ShowClassAndNamespace，就直接顯示 Class + Namespace
#else
// 如果沒有定義 ShowClassAndNamespace，就顯示 Result
#define ShowResult
#endif

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
                try
                {
                    test.Setup();

                    // Delay to allow the test to setup
                    Task.Delay(200).Wait();

#if ShowClassAndNamespace
                    Print(ConsoleColor.Green, $"Namespace: {test.GetType().Namespace}", $"Clss: {test.GetType().Name}");
#endif
#if ShowResult
                    string msg = test.Run();
                    Print(ConsoleColor.Green, $"Result: {msg}");
#endif
                }
                catch (Exception ex)
                {
                    Print(ConsoleColor.Red, $"Error: {ex.Message}");
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
            {
                Console.WriteLine(m);
            }
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
            foreach (var m in msgs)
            {
                Console.WriteLine(m);
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
