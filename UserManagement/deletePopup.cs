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
    public partial class deletePopup : Form
    {
        string _username;
        Form _loggedin;
        UserService _userService;
        public EventHandler UserUpdated;
        public deletePopup(string username, Form loggedin, UserService userService)
        {
            InitializeComponent();
            _username = username;
            _loggedin = loggedin;
            _userService = userService;
        }
        public deletePopup(string username, UserService userService)
        {
            InitializeComponent();
            _username = username;
            _loggedin = this;
            _userService = userService;
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            if (_userService.DeleteAccount(_username))
            {
                PopUp accountDelete = new PopUp("Account Deleted");
                accountDelete.ShowDialog();
                _loggedin.Close();
                UserUpdated?.Invoke(this, EventArgs.Empty);
                this.Close();
            } else
            {
                PopUp accountnoDelete = new PopUp("Account Couldn't Be Deleted");
                accountnoDelete.ShowDialog();
            }
        }
    }
}
