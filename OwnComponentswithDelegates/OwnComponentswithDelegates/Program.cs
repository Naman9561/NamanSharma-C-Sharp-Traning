namespace OwnComponentswithDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Attach console logger
            Logger.WriteMessage += LoggingMethods.LogToConsole;

            // Attach file logger
            var fileLogger = new FileLogger("log.txt");

            // Sample log messages
            Logger.LogMessage(Severity.Information, "Startup", "Application is starting...");
            Logger.LogMessage(Severity.Error, "AuthService", "Invalid login attempt.");
            Logger.LogMessage(Severity.Warning, "Config", "Deprecated setting used.");

            // Detach console logger
            Logger.WriteMessage -= LoggingMethods.LogToConsole;

            // Logs only to file now
            Logger.LogMessage(Severity.Critical, "System", "Unhandled exception occurred!");

            // Optionally detach file logger if no longer needed
            fileLogger.DetachLog();
        }
    }
}
