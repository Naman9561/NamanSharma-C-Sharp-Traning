using System;
using System.IO;

namespace OwnComponentswithDelegates
{
    internal class FileLogger
    {
        private readonly string logPath;

        public FileLogger(string path)
        {
            logPath = path;
            Logger.WriteMessage += LogMessage;
        }

        public void DetachLog() => Logger.WriteMessage -= LogMessage;

        private void LogMessage(string msg)
        {
            try
            {
                using (var log = File.AppendText(logPath))
                {
                    log.WriteLine(msg);
                    log.Flush();
                }
            }
            catch (Exception)
            {
                // Logging failed – silently ignore to prevent further issues.
            }
        }
    }
}
