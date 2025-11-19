using CarWashManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWashManagement.UI
{
    static class Program
    {
        // Required attribute for Windows Form to function properly.
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm loginForm = new LoginForm();

            Application.Run(loginForm);

            /*Application.Run(new DashboardForm(new User
            {
                Username = "admin",
                FullName = "Default Administrator",
                Role = "ADMIN",
                Status = "ACTIVE",
                FailedLoginAttempts = 0
            }));*/
        }
    }
}
