using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using BL;
using DAL;
using Model;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace UserManagement
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static readonly log4net.ILog log = LogHelper.GetLogger();
        [STAThread]
        static void Main()
        {
            log.Info("Application Started");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                log.Info("Setting Up Database");
                Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
                
                DataContext context = new DataContext();
                UnitOfWork unitOfWork = new UnitOfWork(context);
                UserService userService = new UserService(unitOfWork);

                log.Info("Checking for default user");
                // ensure default admin account is created
                var adminUser = context.Users.FirstOrDefault(u => u.UserName == "Admin");
                if (adminUser == null)
                {
                    log.Info("No Admin Account Found, Creating Admin Account");
                    unitOfWork.Users.CreateUser("admin", PasswordHelper.HashPassword("password"), "Admin");
                    unitOfWork.Save();
                }

                context.Users.FirstOrDefault(); // warmup entity framework
                loginForm login = new loginForm(userService);
                login.StartPosition = FormStartPosition.CenterScreen;
                log.Info("Launching Form");
                Application.Run(login);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Startup error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Fatal("Unhandled exception during startup.", ex);
            }
        }
    }

}

// Checklist []
// Entity Framework [/]
// Dependency Injection [?]
// Unit of Work [?]
