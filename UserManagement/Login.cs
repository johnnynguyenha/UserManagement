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
using BL;
using Model;


namespace UserManagement
{
    // main login page. user enters username and password to login.
    public partial class loginForm : Form
    {
        UserService _userService;
        public loginForm(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        // FUNCTIONS //

        // EVENTS //

        // user presses login button. if login is successful, open logged in form. if not, display error message.
        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = passwordBox.Text;
            if (_userService.Login(username, password, out string message))
            {
                var user = _userService.GetUserByUsername(username);
                loggedInForm loginForm = new loggedInForm(user, _userService, this);
                loginForm.Show();
                this.Hide();
            } else
            {
                MessageBox.Show(message);
            }
            
        }
        // user presses forgot password button. opens forgot password form.
        private void forgotPasswordButton_Click(object sender, EventArgs e)
        {
            forgotPasswordForm changePasswordForm = new forgotPasswordForm(_userService);
            changePasswordForm.Show();
        }
        // user presses sign up button. opens sign up form.
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signup = new SignUp(_userService);
            signup.Show();
        }
    }
}
