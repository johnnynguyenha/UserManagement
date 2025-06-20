using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using BL;
using DAL;
using Model;

namespace UserManagement
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());

            DataContext context = new DataContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);
            UserService userService = new UserService(unitOfWork);

            // ensure default admin account is created
            var adminUser = context.Users.FirstOrDefault(u => u.UserName == "Admin");
            if (adminUser == null)
            {
                unitOfWork.Users.CreateUser("admin", "password", "Admin");
                unitOfWork.Save();
            }

            context.Users.FirstOrDefault(); // warmup entity framework
            loginForm login = new loginForm(userService);
            login.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(login);
        }
    }

}

// Checklist []
// Entity Framework [/]
// Dependency Injection [?]
// Unit of Work [?]
