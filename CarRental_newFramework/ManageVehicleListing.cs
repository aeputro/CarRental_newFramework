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
    public partial class ManageVehicleListing : Form
    {
        private readonly CarRentalEntities _db;
        public ManageVehicleListing()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void ManageVehicleListing_Load(object sender, EventArgs e)
        {
            var cars = _db.TypesOfCars
                        .Select(q => new 
                        { 
                            CarName = q.Maker,
                            CarModel = q.Model, 
                            CarVIN = q.VIN, 
                            Year = q.Year, 
                            LicencePlateNumber = q.LicensePlateNumber,
                            q.Id
                        })
                        .ToList();
            dgvVehicleList.DataSource = cars;
            dgvVehicleList.Columns[0].HeaderText = "Car Name";
            dgvVehicleList.Columns[1].HeaderText = "Car Model";
            dgvVehicleList.Columns[2].HeaderText = "Car VIN";
            dgvVehicleList.Columns[3].HeaderText = "Year";
            dgvVehicleList.Columns[4].HeaderText = "Plate Number";
            dgvVehicleList.Columns[5].Visible = false;

        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            AddEditVehicles addEditVehicles = new AddEditVehicles(this);
            addEditVehicles.MdiParent = this.MdiParent;
            addEditVehicles.Show();
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {

            try
            {
                //Get Id from selected row on DGV
                var id = (int)dgvVehicleList.SelectedRows[0].Cells["Id"].Value;

                //Query to DB from fetched Id
                var car = _db.TypesOfCars.FirstOrDefault(q => q.Id == id);

                //Launch window with fetched data from DB
                AddEditVehicles addEditVehicles = new AddEditVehicles(car,this);
                addEditVehicles.MdiParent = this.MdiParent;
                addEditVehicles.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            try
            {
                //Get Id from selected row on DGV
                var id = (int)dgvVehicleList.SelectedRows[0].Cells["Id"].Value;

                //Query to DB from fetched Id
                var car = _db.TypesOfCars.FirstOrDefault(q => q.Id == id);

                //Delete data query to DB

                DialogResult dr = MessageBox.Show("Are you sure want to delete this record?"
                                                  ,"Confirmation",MessageBoxButtons.OKCancel
                                                  ,MessageBoxIcon.Warning);
                if(dr == DialogResult.OK)
                {
                    _db.TypesOfCars.Remove(car); //remove object resulted from query
                    _db.SaveChanges();
                }
                PopulateGrid();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        public void PopulateGrid()
        {
            var cars = _db.TypesOfCars
                        .Select(q => new
                        {
                            CarName = q.Maker,
                            CarModel = q.Model,
                            CarVIN = q.VIN,
                            Year = q.Year,
                            LicencePlateNumber = q.LicensePlateNumber,
                            q.Id
                        })
                        .ToList();
            dgvVehicleList.DataSource = cars;
            dgvVehicleList.Columns[0].HeaderText = "Car Name";
            dgvVehicleList.Columns[1].HeaderText = "Car Model";
            dgvVehicleList.Columns[2].HeaderText = "Car VIN";
            dgvVehicleList.Columns[3].HeaderText = "Year";
            dgvVehicleList.Columns[4].HeaderText = "Plate Number";
            dgvVehicleList.Columns[5].Visible = false;
        }
    }
}
