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

    // form for changing password from manage menu (admin is changing someone else's password).
    public partial class AdminChangePassword : Form
    {
        private readonly UserService _userService;
        private string _username;
        User _user;
        private string _password;
        public AdminChangePassword(UserService userService, User user)
        {
            InitializeComponent();
            _userService = userService;
            _user = user;
            _username = _user.UserName;
            _password = user.Password;
        }

        // FUNCTIONS //

        // EVENTS //

        // user presses apply button to change password. display message if successful or not.

        private void applyButton_Click_1(object sender, EventArgs e)
        {
            string newpassword = newPasswordBox.Text;
            string confirmpassword = confirmPasswordBox.Text;
            string message = "";
            if (_userService.ChangePassword(_username, _password, newpassword, confirmpassword, out message))
            {
                MessageBox.Show(message);
                this.Close();
            }
            else
            {
                MessageBox.Show(message);
            }
        }
    }
}
