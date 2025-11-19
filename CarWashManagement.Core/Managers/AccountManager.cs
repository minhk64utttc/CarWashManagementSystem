using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWashManagement.Core.FileHandlers;

namespace CarWashManagement.Core.Managers
{
    public class AccountManager
    {
        // Declaration of fields for the file handler objects.
        private readonly IFileHandler<User> userFileHandler;
        private readonly AuditFileHandler auditFileHandler;

        // The maximum number of failed login attempts.
        private const int MaxLoginAttempts = 3;

        private List<User> users;

        // Initialize file handlers when AccountManager is created.
        public AccountManager(IFileHandler<User> userFileHandler, AuditFileHandler auditFileHandler)
        {
            users = userFileHandler.Load(); 

            this.userFileHandler = userFileHandler;
            this.auditFileHandler = auditFileHandler;

            // Checks if there are any users in users.txt.
            // If none, it creates the default admin account.
            if (!userFileHandler.Load().Any())
            {
                CreateUser("admin", "admin123", "ADMIN", "Default Administrator");
                auditFileHandler.LogEvent("INFO: No users found. Default 'admin' account created.");
            }
        }

        // Method to log a user in.
        public string Login(string username, string password, out User loggedInUser)
        {
            loggedInUser = null; // Initializes the user to null.

            // Get all users from the users.txt file.
            users = GetAllUsers();

            // Gets the first matching username from the users list, ignoring case; otherwise, sets to null.
            User user = users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            // Check for failure conditions.
            if (user == null)
            {
                auditFileHandler.LogEvent($"FAILURE: Failed login attempt for non-existent user '{username}'.");
                return "Username or password is incorrect.";
            }

            if (user.Status == "INACTIVE")
            {
                auditFileHandler.LogEvent($"FAILURE: Login attempt for inactive user '{username}'.");
                return "This account is inactive. Please contact an administrator.";
            }

            if (user.Status == "LOCKED")
            {
                auditFileHandler.LogEvent($"FAILURE: Login attempt for locked user '{username}'.");
                return "This account is locked due to too many failed attempts.";
            }

            // Check the password
            if (user.Password != password)
            {
                // Increments the failed login attempts property of the user.
                user.FailedLoginAttempts++;
                auditFileHandler.LogEvent($"FAILURE: Failed login attempt for user '{username}'.");

                string failureMessage = "Username or password is incorrect.";

                // Handle account locking.
                if (user.FailedLoginAttempts >= MaxLoginAttempts)
                {
                    user.Status = "LOCKED";
                    failureMessage = "Account has been locked due to too many failed attempts.";
                    auditFileHandler.LogEvent($"LOCKOUT: Account for user '{username}' has been locked.");
                }

                // Save the changes (updated attempts or status update)
                userFileHandler.Save(users);
                return failureMessage;
            } else
            {
                user.FailedLoginAttempts = 0; // Reset attempts when login is successful.
                userFileHandler.Save(users); // Save the reset count.

                auditFileHandler.LogEvent($"SUCCESS: User '{username}' logged in.");
                loggedInUser = user; // Pass the user object back.
                return "SUCCESS";
            }
        }

        // Method to activate a user account.
        public bool ActivateUser(string username)
        {
            User user = users.FirstOrDefault(u => u.Username == username);

            if (user != null && user.Status != "ACTIVE")
            {
                user.Status = "ACTIVE";
                user.FailedLoginAttempts = 0;
                userFileHandler.Save(users);
                auditFileHandler.LogEvent($"INFO: Account for user '{username}' has been activated.");
                return true;
            } else
            {
                return false;
            }

        }

        // Method to deactivate a user account.
        public bool DeactivateUser(string username)
        {
            User user = users.FirstOrDefault(u => u.Username == username);

            if (user != null && user.Status != "INACTIVE")
            {
                user.Status = "INACTIVE";
                user.FailedLoginAttempts = 0;
                userFileHandler.Save(users);
                auditFileHandler.LogEvent($"INFO: Account for user '{username}' has been deactivated.");
                return true;
            }
            else
            {
                return false;
            }
        }

        // Method to allow users to change their password.
        public bool ChangePassword(string loggedInUsername, string oldPassword, string newPassword)
        {
            User user = GetUser(loggedInUsername);

            if (user == null)
            {
                return false;
            }

            // Verify the old password.
            if (user.Password != oldPassword)
            {
                auditFileHandler.LogEvent($"SECURITY: User '{loggedInUsername}' failed to change their password. (Incorrect old password).");
                return false;
            }

            user.Password = newPassword;

            userFileHandler.Save(users);
            auditFileHandler.LogEvent($"SECURITY: User '{loggedInUsername}' successfully changed their password.");
            return true;
        }

        // Method to create a new user.
        public bool CreateUser(string username, string password, string role, string fullName)
        {
            // Check if user already exists.
            if (users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                return false; // The user already exists.

            } else
            {
                // Create the new user object.
                User newUser = new User
                {
                    Username = username,
                    Password = password,
                    Role = role.ToUpper(),
                    FullName = fullName,
                    Status = "ACTIVE",
                    FailedLoginAttempts = 0
                };

                users.Add(newUser);
                userFileHandler.Save(users);
                auditFileHandler.LogEvent($"INFO: New user '{username}' created with role '{role}'.");
                return true;
            }
        }

        // Method to get the user object from user list using the username.
        public User GetUser(string username)
        {
            return users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        // Method to get the list of all users from the user.txt file.
        public List<User> GetAllUsers()
        {
            return userFileHandler.Load();
        }

    }
}
