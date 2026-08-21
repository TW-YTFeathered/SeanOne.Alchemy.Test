using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;

namespace SeanOne.Alchemy.Test
{
    static class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            bool isInteractive = !Console.IsInputRedirected && !Console.IsOutputRedirected;
            TestFactory.EnableDisplayDelay = isInteractive;

            DisplayRuntimeVersion();
            
            TestFactory.RunTest();

            Console.WriteLine($"Test count: {TestFactory.RunCount}, " +
                              $"Correct: {TestFactory.CorrectCount}, " +
                              $"Incorrect: {TestFactory.IncorrectCount}, " +
                              $"Error: {TestFactory.ErrorCount}");

            if (isInteractive)
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void DisplayRuntimeVersion()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Runtime version: {RuntimeInformation.FrameworkDescription}");

            var assembly = typeof(Alchemy).Assembly;
            var targetFrameworkAttr = assembly.GetCustomAttribute<TargetFrameworkAttribute>();
            string targetFramework = targetFrameworkAttr?.FrameworkName ?? "Unknown";

            Console.WriteLine($"Nuget target framework: {targetFramework}");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
