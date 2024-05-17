using System.Diagnostics;

namespace Karate_Club_Data_Access
{
    internal class clsErrorsLogger
    {
        public static void LogError(string message)
        {
            string sourceName = "Karate_Club";
            string logName = "Application";

            // Create the event source if it does not exist
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, logName);
            }

            // Log an error event
            EventLog.WriteEntry(sourceName, message, EventLogEntryType.Error);
        }
    }
}
