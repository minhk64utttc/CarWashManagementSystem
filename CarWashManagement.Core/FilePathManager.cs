using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashManagement.Core
{
    public static class FilePathManager
    {
        // This is the main folder where all the data will be stored.
        public static readonly string DataFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CarWashManager");

        // Declaration of properties to get the full path to each data file.
        public static string UsersFilePath => Path.Combine(DataFolderPath, "users.txt");
        public static string VehiclesFilePath => Path.Combine(DataFolderPath, "vehicles.txt");
        public static string ServicesFilePath => Path.Combine(DataFolderPath, "services.txt");
        public static string TransactionsFilePath => Path.Combine(DataFolderPath, "transactions.txt");
        public static string ExpensesFilePath => Path.Combine(DataFolderPath, "expenses.txt");
        public static string AuditLogFilePath => Path.Combine(DataFolderPath, "audit.log");

        static FilePathManager()
        {
            // Creates the directory to the systems' AppData folder if it doesn't exist yet.
            Directory.CreateDirectory(DataFolderPath);
        }
    }
}
