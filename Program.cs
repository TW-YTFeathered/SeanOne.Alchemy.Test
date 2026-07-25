using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace SeanOne.Alchemy.Test
{
    static class Program
    {
        static void Main()
        {
            bool isInteractive = !Console.IsInputRedirected && !Console.IsOutputRedirected;

            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            DisplayRuntimeVersion();

            TestFactory.EnableDisplayDelay = isInteractive;
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

            Console.WriteLine($"Nuget package version: {targetFramework}");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
