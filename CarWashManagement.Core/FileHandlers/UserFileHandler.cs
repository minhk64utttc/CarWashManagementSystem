using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashManagement.Core.FileHandlers
{
    // File handler class for managing user data in users.txt file.
    public class UserFileHandler : IFileHandler<User>
    {   
        // Get the file path of users.txt using the FilePathManager class.
        private readonly string filePath = FilePathManager.UsersFilePath;

        // Method to read all lines from users.txt and converts it into a list of User objects.
        public List<User> Load()
        {
            List<User> users = new List<User>();

            // Check if the file exists
            if (!File.Exists(filePath))
            {
                return users; // Return an empty list.

            } else
            {
                // Read all lines from the users.txt.
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    try
                    {
                        // Split the line by '|' delimiter.
                        string[] parts = line.Split('|');

                        // Make sure that it has all 6 properties.
                        if (parts.Length == 6)
                        {
                            // Create a new User object.
                            User user = new User
                            {
                                Username = parts[0],
                                Password = parts[1],
                                Role = parts[2].ToUpper(),
                                FullName = parts[3],
                                Status = parts[4].ToUpper(),
                                FailedLoginAttempts = int.Parse(parts[5])
                            };

                            users.Add(user);
                        }
                    } catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing user file line: {line}.\nError: {ex.Message}");
                    }
                }

                return users;
            }
        }

        // Method to overwrite the users.txt with the new data.
        public void Save(List<User> users)
        {
            List<string> lines = new List<string>();

            foreach (User user in users)
            {
                // Joins the data into a string using the delimiter.
                string line = string.Join("|",
                    user.Username,
                    user.Password,
                    user.Role,
                    user.FullName,
                    user.Status,
                    user.FailedLoginAttempts);

                lines.Add(line);
            }

            // Writes the data from the list to the user.txt file.
            File.WriteAllLines(filePath, lines);
        }
    }
}
