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
    public partial class ManageRentalRecords : Form
    {
        private readonly CarRentalEntities _db;

        public ManageRentalRecords()
        {
            InitializeComponent();
            _db = new CarRentalEntities();

        }

        private void ManageRentalRecords_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void PopulateGrid()
        {
            var rentalRecords = _db.CarRentalRecords
                                .Select(q => new
                                {
                                    CustName = q.CustomerName,
                                    Cost = q.Cost,
                                    DateRented = q.DateRented,
                                    DateReturned = q.DateReturned,
                                    Id = q.id,
                                    Car = q.TypesOfCar.Maker + " " + q.TypesOfCar.Model
                                }).ToList();

            dgvRentalRecords.DataSource = rentalRecords;
            dgvRentalRecords.Columns["DateRented"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvRentalRecords.Columns["DateReturned"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvRentalRecords.Columns["Id"].Visible = false;

        }

        private void btnAddNewRecord_Click(object sender, EventArgs e)
        {
            var addRentalRecord = new AddRentalRecord();
            addRentalRecord.MdiParent = this.MdiParent;
            addRentalRecord.Show();
        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            var id = (int)dgvRentalRecords.SelectedRows[0].Cells["Id"].Value;
            var record = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);
            var addRentalRecord = new AddRentalRecord(record);
            addRentalRecord.MdiParent = this.MdiParent;
            addRentalRecord.Show();

        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            var id = (int)dgvRentalRecords.SelectedRows[0].Cells["Id"].Value;
            var record = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);

            _db.CarRentalRecords.Remove(record);
            _db.SaveChanges();

            PopulateGrid();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }
    }
}
