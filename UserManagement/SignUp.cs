using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using Model;

namespace UserManagement
{
    // form for signing up a new user (user is not logged in). user must enter username and password in order to register.
    public partial class SignUp : Form
    {
        UserService _userService;
        public SignUp(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }
        // user presses register button to create a new account. display message if successful or not.
        private void registerButton_Click(object sender, EventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Text;
            string confirmPassword = confirmPasswordBox.Text;
            string message = "";
            if (password == confirmPassword)
            {
                _userService.Register(username, password, confirmPassword, out message);
            }
            else
            {
                message = "Passwords do not match";
            }
            MessageBox.Show(message);
        }
    }
}
