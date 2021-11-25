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
    public partial class AddUser : Form
    {

        private readonly CarRentalEntities _db;

        private ManageUsers _manageUsers;
        public AddUser(ManageUsers manageUsers)
        {
            InitializeComponent();
            _db = new CarRentalEntities();
            _manageUsers = manageUsers;
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            var role = _db.Roles.ToList();
            cboRolesUserName.DataSource = role;
            cboRolesUserName.ValueMember = "id";
            cboRolesUserName.DisplayMember = "name";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                var userName = tAddUserName.Text;
                var roleId = (int)cboRolesUserName.SelectedValue;
                var password = Utils.DefaultHashPassword();

                var user = new User
                {

                    username = userName,
                    password = password,
                    isActive = true

                };

                _db.Users.Add(user);
                _db.SaveChanges();

                //Now adding this User id to UserRole table

                var userid = user.id;
                var userrole = new UserRole
                {
                    userid = userid,
                    roleid = roleId
                };

                _db.UserRoles.Add(userrole);
                _db.SaveChanges();

                MessageBox.Show("New user added successfully");
                _manageUsers.PopulateGrid();
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error has occured");
            }
            

        }
    }
}
