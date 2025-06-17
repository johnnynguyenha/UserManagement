using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using BL;

namespace UserManagement
{
    public partial class PopUp : Form
    {
        public PopUp(string message)
        {
            InitializeComponent();
            errorLabel.Text = message;
        }
    }
}
