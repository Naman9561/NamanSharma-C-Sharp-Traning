using System;

namespace OwnComponentswithDelegates
{
    internal class LoggingMethods
    {
        public static void LogToConsole(string message)
        {
            Console.Error.WriteLine(message);
        }
    }
}
