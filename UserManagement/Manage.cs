using BL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UserManagement
{
    public partial class Manage : Form
    {
        List<User> userList;
        UserService _userService;
        string _username;
        bool _editVisible;
        public Manage(UserService userService, string username)
        {
            InitializeComponent();
            _userService = userService;
            userList = _userService.GetUserList();
            FillList();
            _username = username;
            editInvisible();
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_editVisible)
            {
                var username = listBox1.SelectedItem.ToString();
                User user = _userService.GetUserByUsername(username);
                usernameBox.Text = user.UserName;
                passwordBox.Text = user.Password;
                firstNameBox.Text = user.FirstName;
                lastNameBox.Text = user.LastName;
                phoneBox.Text = user.PhoneNumber;
                addressBox.Text = user.Address;

            }
        }

        private void Manage_Load(object sender, EventArgs e)
        {

        }

        private void FillList()
        {
            listBox1.Items.Clear();
            userList = _userService.GetUserList();
            foreach (User user in userList)
            {
                if (user != null)
                {
                    listBox1.Items.Add(_userService.GetUserName(user));
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string username = listBox1.SelectedItem.ToString();
                deletePopup delete = new deletePopup(username, _userService);
                delete.UserUpdated += UserUpdated;
                delete.Show();
            }
        }
        private void UserUpdated(object sender, EventArgs e)
        {
            FillList();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                editVisible();
                string username = listBox1.SelectedItem.ToString();
                User user = _userService.GetUserByUsername(username);
                usernameBox.Text = user.UserName;
                passwordBox.Text = user.Password;
                firstNameBox.Text = user.FirstName;
                lastNameBox.Text = user.LastName;
                phoneBox.Text = user.PhoneNumber;
                addressBox.Text = user.Address;
            }
        }

        private void editInvisible()
        {
            usernameLabel.Visible = false;
            passwordLabel.Visible = false;
            firstNameLabel.Visible = false;
            lastNameLabel.Visible = false;
            phoneLabel.Visible = false;
            addressLabel.Visible = false;
            usernameBox.Visible = false;
            passwordBox.Visible = false;
            firstNameBox.Visible = false;
            lastNameBox.Visible = false;
            phoneBox.Visible = false;
            addressBox.Visible = false;
            applyButton.Visible = false;
            _editVisible = false;
        }

        private void editVisible()
        {
            usernameLabel.Visible = true;
            passwordLabel.Visible = true;
            firstNameLabel.Visible = true;
            lastNameLabel.Visible = true;
            phoneLabel.Visible = true;
            addressLabel.Visible = true;
            usernameBox.Visible = true;
            passwordBox.Visible = true;
            firstNameBox.Visible = true;
            lastNameBox.Visible = true;
            phoneBox.Visible = true;
            addressBox.Visible = true;
            applyButton.Visible = true;
            _editVisible = true;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Text;
            string firstName = firstNameBox.Text;
            string lastName = lastNameBox.Text;
            string phoneNumber = phoneBox.Text;
            string address = addressBox.Text;
            _userService.ChangeDetails(username, password, firstName, lastName, phoneNumber, address);
            FillList();
        }
    }
}
