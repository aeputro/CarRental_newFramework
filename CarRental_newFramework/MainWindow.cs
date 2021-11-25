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
    public partial class MainWindow : Form
    {
        private Login _login;
        //public string _roleShortName;
        public string _roleName;
        public User _user;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(Login login,User user)
        {
            InitializeComponent();
            _login = login;
            //_roleShortName = roleShortName;
            _user = user;
            _roleName = user.UserRoles.FirstOrDefault().Role.shortname;
        }

        private void addRentalRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openForms = Application.OpenForms.Cast<Form>(); //declare variable to see any open form
            var isOpen = openForms.Any(q => q.Name == "AddRentalRecord");
            if (!isOpen)
            {
                var addRentalRecord = new AddRentalRecord();
                addRentalRecord.MdiParent = this;
                addRentalRecord.Show();
            }

        }

        private void manageVehicleListingToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //var openForms = Application.OpenForms.Cast<Form>();
            //var isOpen = openForms.Any(q => q.Name == "ManageVehicleListing");
            //if (!isOpen)
            //{
            //    var manageVehicleListing = new ManageVehicleListing();
            //    manageVehicleListing.MdiParent = this;
            //    manageVehicleListing.Show();
            //}

            if (!Utils.FormIsOpen("ManageVehicleListing"))
            {
                var manageVehicleListing = new ManageVehicleListing();
                manageVehicleListing.MdiParent = this;
                manageVehicleListing.Show();
            }
        }

            private void viewArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //var openForms = Application.OpenForms.Cast<Form>();
            //var isOpen = openForms.Any(q => q.Name == "ManageRentalRecords");
            //if (!isOpen)
            //{
            //    var manageRentalRecords = new ManageRentalRecords();
            //    manageRentalRecords.MdiParent = this;
            //    manageRentalRecords.Show();
            //}

            if (!Utils.FormIsOpen("ManageRentalRecords"))
            {
                var manageRentalRecords = new ManageRentalRecords();
                manageRentalRecords.MdiParent = this;
                manageRentalRecords.Show();
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Show();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if(_user.password == Utils.DefaultHashPassword())
            {
                var resetPassword = new ResetPassword(_user);
                resetPassword.ShowDialog();
            }
            
            var username = _user.username;
            tst1.Text = $"Logged in as {username}";
            
            if(_roleName != "admin")
            {
                manageRentalRecordToolStripMenuItem.Visible = false;
            }
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var manageUsers = new ManageUsers();
            manageUsers.MdiParent = this;
            manageUsers.Show();
        }
    }
}

