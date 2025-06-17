using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BL;
using Model;


namespace UserManagement
{
    public partial class loginForm : Form
    {
        // DataService dataService;
        UserService _userService;
        UnitOfWork _unitOfWork;
        public loginForm()
        {
            InitializeComponent();
            DataContext context = new DataContext();
            context.Users.FirstOrDefault(); // warmup entity framework
            // dataService = new DataService(context);
            _unitOfWork = new UnitOfWork(context);
            _userService = new UserService(_unitOfWork);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = passwordBox.Text;
            string message = "";
            if (_userService.Login(username, password, out message))
            {
                loggedInForm loginForm = new loggedInForm(username, _userService);
                loginForm.Show();
                
            } else
            {
                PopUp popupForm = new PopUp(message);
                popupForm.Show();
            }
            
        }

        private void forgotPasswordButton_Click(object sender, EventArgs e)
        {
            forgotPasswordForm changePasswordForm = new forgotPasswordForm(_userService, "");
            changePasswordForm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signup = new SignUp(_userService);
            signup.Show();
        }
    }
}
