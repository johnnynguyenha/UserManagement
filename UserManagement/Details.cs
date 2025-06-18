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

    // popup for showing user details (user must be logged in). also allows for user to go to change password form.
    public partial class Details : Form
    {
        UserService _userService;
        string _username;
        string _password;
        User _user;

        public Details(UserService userService, User user)
        {
            InitializeComponent();
            _userService = userService;
            _user = user;
            _username = _user.UserName;
            fillDetails();
            enableBoxes(false);
            _password = _userService.GetPassword(_username);
        }

        // FUNCTIONS //

        // fills the text boxes with user details of the User. if there's an error, show message box.
        private void fillDetails()
        {
            var user = _user;
            if (user != null)
            {
                usernameBox.Text = user.UserName;
                firstNameBox.Text = user.FirstName;
                lastNameBox.Text = user.LastName;
                phoneBox.Text = user.PhoneNumber;
                addressBox.Text = user.Address;
            }
            else
            {
                MessageBox.Show("User not found.");
                this.Dispose();
            }
        }

        // enable or disable if user can edit boxes.

        private void enableBoxes(bool setting)
        {
            usernameBox.Enabled = setting;
            passwordBox.Enabled = false;
            firstNameBox.Enabled = setting;
            lastNameBox.Enabled = setting;
            phoneBox.Enabled = setting;
            addressBox.Enabled = setting;
        }

        // EVENTS //

        // user presses edit button to enable text boxes for editing.

        private void editButton_Click(object sender, EventArgs e)
        {
            enableBoxes(true);
        }

        // user presses apply to save details. if successful, show message box. if not, show error message.
        private void applyButton_Click(object sender, EventArgs e)
        {
            enableBoxes(false);
            if (usernameBox.Text == string.Empty)
            {
                MessageBox.Show("Username cannot be empty.");
                return;
            }
            string newusername = usernameBox.Text;
            string firstName = firstNameBox.Text;
            string lastName = lastNameBox.Text;
            string phoneNumber = phoneBox.Text;
            string address = addressBox.Text;
            if (_userService.ChangeDetailsNoPassword(_user, _username, newusername, firstName, lastName, phoneNumber, address))
            {
                MessageBox.Show("Details were successfully changed");
                _username = newusername;
                _user = _userService.GetUserByUsername(_username);
            }
            else
            {
                MessageBox.Show("Details were not successfully changed");
            }
            fillDetails();
        }

        // user presses change password button, show change password form.
        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(_userService, _user);
            changePassword.Show();
        }
    }
}
