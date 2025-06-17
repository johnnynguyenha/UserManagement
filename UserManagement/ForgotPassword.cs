using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class forgotPasswordForm : Form
    {
        private readonly UserService _userService;
        private string _username;

        public forgotPasswordForm(UserService userService, string username)
        {
            InitializeComponent();
            _userService = userService;
            _username = username;
            usernameBox.Text = _username;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            string newpassword = newPasswordBox.Text;
            string confirmpassword = confirmPasswordBox.Text;
            string message = "";
            if (_userService.ResetPassword(_username, newpassword, confirmpassword, out message))
            {
                PopUp popupForm = new PopUp(message);
                popupForm.Show();
                Console.WriteLine("Password Changed!");
            }
            else
            {
                PopUp popupForm = new PopUp(message);
                popupForm.Show();
            }
        }
    }
}
