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
using DAL;
using Model;

namespace UserManagement
{
    public partial class loggedInForm : Form
    {
        UserService _userService;
        string _username;
        public loggedInForm(string username, UserService userService)
        {
            InitializeComponent();
            _username = username;
            _userService = userService;
            titleLabel.Text = "Welcome " + _username;
            checkRole();

        }

        private void editDetailsButton_Click(object sender, EventArgs e)
        {
            forgotPasswordForm forgotPasswordForm = new forgotPasswordForm(_userService, _username);
            forgotPasswordForm.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            deletePopup deletePop = new deletePopup(_username, this, _userService);
            deletePop.Show();
        }

        private void manageButton_Click(object sender, EventArgs e)
        {
            Manage manage = new Manage(_userService, _username);
            manage.Show();
        }

        private void titleLabel_Click(object sender, EventArgs e)
        {

        }

        private void checkRole()
        {
            if (_userService.GetRole(_username) == "Admin")
            {
                manageButton.Show();
            } else
            {
                manageButton.Hide();
            }
        }

        private void editDetailsButton_Click_1(object sender, EventArgs e)
        {

        }
    }
}
