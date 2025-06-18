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

    // Form for when user is logged in. Displays different if user is an admin or a regular user.
    public partial class loggedInForm : Form
    {
        UserService _userService;
        User _user;
        string _username;
        Form _login;
        public loggedInForm(User user, UserService userService, Form login)
        {
            InitializeComponent();
            _userService = userService;
            _user = user;
            _username = _user.UserName;
            _login = login;
            titleLabel.Text = "Welcome " + _username;
            checkRole();
        }
        // FUNCTIONS //

        // function to check if the user is an admin. if the user is an admin, show/hide manage button.
        private void checkRole()
        {
            if (_userService.GetRole(_user) == "Admin")
            {
                manageButton.Show();
            }
            else
            {
                manageButton.Hide();
            }
        }

        // EVENTS //

        // User presses delete button to delete their account. Displays delete account form.
        private void deleteButton_Click(object sender, EventArgs e)
        {
            deletePopup deletePop = new deletePopup(_user, this, _userService);
            deletePop.StartPosition = FormStartPosition.CenterScreen;
            deletePop.Show();
        }
        // user presses manage button. if user is an admin, opens manage form to manage users.
        private void manageButton_Click(object sender, EventArgs e)
        {
            if (_userService.GetRole(_user) != "Admin")
            {
                MessageBox.Show("You do not have permission to manage users.");
                return;
            }
            Manage manage = new Manage(_userService, _user);
            manage.StartPosition = FormStartPosition.CenterScreen;
            manage.Show();
        }
        // user presses edit details button. opens details form.
        private void editDetailsButton_Click_1(object sender, EventArgs e)
        {
            Details editDetails = new Details(_userService, _user);
            editDetails.StartPosition = FormStartPosition.CenterScreen;
            editDetails.Show();
        }

        // user presses log out button. closes the form and returns to login screen
        private void logOutButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            _login.Show();
        }
    }
}
