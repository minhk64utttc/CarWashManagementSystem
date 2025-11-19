using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CarWashManagement.Core.FileHandlers
{
    // File handler class for managing audit log events in audit.log file.
    public class AuditFileHandler
    {
        private readonly string filePath = FilePathManager.AuditLogFilePath;

        // Appends a new event message to the audit.log file.
        public void LogEvent(string message)
        {
            try
            {
                // Create the timestamp
                string logEntry = $"[{DateTime.Now:MM-dd-yyyy HH:mm:ss}] {message}\n";

                // Appends the log entry to the audit.log file.
                File.AppendAllText(filePath, logEntry);
                
            } catch (Exception ex) 
            {
                Console.WriteLine($"Could not write to audit log. Error: {ex.Message}");
            }
        }
    }
}
