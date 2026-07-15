using SeanOne.Alchemy.Test;
using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace SeanOne.Alchemy.Test
{
    static class Program
    {
        static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Runtime version: {RuntimeInformation.FrameworkDescription}");
            Console.ResetColor();

            TestFactory.RunTest();

            Console.ReadKey();
        }
    }
}
