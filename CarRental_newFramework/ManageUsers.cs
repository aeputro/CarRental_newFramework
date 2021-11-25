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
    public partial class ManageUsers : Form
    {
        private readonly CarRentalEntities _db;
        public ManageUsers()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen("AddUser"))
            {
                var addUser = new AddUser(this);
                addUser.MdiParent = this.MdiParent;
                addUser.Show();
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)dgvUsers.SelectedRows[0].Cells["id"].Value;
                var user = _db.Users.FirstOrDefault(q => q.id == id);
                //var newPassword = "Password@123";

                var newPassword = Utils.DefaultHashPassword();

                //var hashedPassword = Utils.HashedPassword(newPassword);

                user.password = newPassword;

                _db.SaveChanges();

                MessageBox.Show($"{user.username}'s has been reset");
            }
            catch (Exception ex)
            {

                MessageBox.Show($"ERROR: {ex.Message}");
            }
        }

        private void btnActivateDeactivateUser_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)dgvUsers.SelectedRows[0].Cells["id"].Value;
                var user = _db.Users.FirstOrDefault(q => q.id == id);

                //if (user.isActive == false)
                //    user.isActive = true;
                //else
                //    user.isActive = false;

                user.isActive = user.isActive == true ? false : true;

                _db.SaveChanges();

                MessageBox.Show($"{user.username}'s has been deactivated");
                PopulateGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"ERROR: {ex.Message}");
            }
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        public void PopulateGrid()
        {
            var users = _db.Users.Select(q => new
            {
                id = q.id,
                UserName = q.username,
                Role = q.UserRoles.FirstOrDefault().Role.name,
                IsActive = q.isActive
            }).ToList();

            dgvUsers.DataSource = users;
            dgvUsers.Columns["UserName"].HeaderText = "UserName";
            dgvUsers.Columns["Role"].HeaderText = "RoleName";
            dgvUsers.Columns["IsActive"].HeaderText = "IsActive";
            dgvUsers.Columns["id"].Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }
    }
}
