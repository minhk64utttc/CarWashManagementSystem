using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CarWashManagement.Core.FileHandlers
{
    // File handler class for managing expenses in expenses.txt file.
    public class ExpenseFileHandler : IFileHandler<Expense>
    {
        private readonly string filePath = FilePathManager.ExpensesFilePath;

        public List<Expense> Load()
        {
            var expenses = new List<Expense>();
            if (!File.Exists(filePath))
            {
                return expenses;
            }

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                try
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 4)
                    {
                        Expense expense = new Expense
                        {
                            Id = Guid.Parse(parts[0]),
                            Date = DateTime.Parse(parts[1]),
                            Description = parts[2],
                            Amount = decimal.Parse(parts[3])
                        };
                        expenses.Add(expense);
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine($"Error parsing expense line: {line}. Exception: {ex.Message}");
                }
            }
            return expenses;
        }

        public void Save(List<Expense> data)
        {
            List<string> lines = new List<string>();

            foreach (Expense expense in data)
            {
                string line = string.Join("|",
                    expense.Id.ToString(),
                    expense.Date.ToString("o"),
                    expense.Description,
                    expense.Amount.ToString("N2")
                );
                lines.Add(line);
            }
            File.WriteAllLines(filePath, lines);
        }
    }
}
