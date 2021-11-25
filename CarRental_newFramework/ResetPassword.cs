using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental_newFramework
{
    public partial class ResetPassword : Form
    {
        private readonly CarRentalEntities _db;
        public User _user;
        public ResetPassword(User user)
        {
            InitializeComponent();
            _db = new CarRentalEntities();
            _user = user;
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            var password = tNewPassword.Text;
            var confirmedpassword = tConfirmedPassword.Text;
            var user = _db.Users.FirstOrDefault(q => q.id == _user.id);

            if(confirmedpassword != password)
            {
                MessageBox.Show("Password do not match, please try again");
            }
            else
            {
                user.password = Utils.HashedPassword(password);

                _db.SaveChanges();
                MessageBox.Show($"Password {_user.username} has been changed");
                this.Close();
            }

            
        }
    }
}
