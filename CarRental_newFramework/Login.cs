using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace CarRental_newFramework
{
    public partial class Login : Form

    {
        private readonly CarRentalEntities _db;
        public Login()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SHA256 sha = SHA256.Create();

                
                var username = tUserName.Text.Trim();
                var password = tPassword.Text;
                //byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

                //StringBuilder stringBuilder = new StringBuilder();

                //for(int i = 0;i < data.Length; i++)
                //{
                //    stringBuilder.Append(data[i].ToString("x2"));
                //}

                //var hashedPassword = stringBuilder.ToString();

                var hashedPassword = Utils.HashedPassword(password);

                var user = _db.Users.FirstOrDefault(q => q.username == username && q.password == hashedPassword
                                                    && q.isActive == true);

                if(user == null)
                {
                    MessageBox.Show("Please provide valid credentials");
                }
                else
                {
                    var role = user.UserRoles.FirstOrDefault();
                    var mainwindow = new MainWindow(this,user);
                    mainwindow.Show();
                    this.Hide();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Something went wrong,please try again");
            }

        }
    }
}
