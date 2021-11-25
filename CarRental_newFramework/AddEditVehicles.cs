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
    public partial class AddEditVehicles : Form
    {

        private bool isEditMode;
        private readonly CarRentalEntities _db;
        private ManageVehicleListing _manageVehicleListing;
        public AddEditVehicles(ManageVehicleListing manageVehicleListing = null)
        {
            InitializeComponent();
            lblTitle.Text = "Add New Vehicle";
            _manageVehicleListing = manageVehicleListing;
            _db = new CarRentalEntities();
            isEditMode = false;
        }

        public AddEditVehicles(TypesOfCar carToEdit, ManageVehicleListing manageVehicleListing = null)
        {
            InitializeComponent();
            if(carToEdit == null)
            {
                MessageBox.Show("Please ensure that you selected a valid record to edit");
            }
            else
            {
                lblTitle.Text = "Edit Vehicle";
                isEditMode = true;
                _manageVehicleListing = manageVehicleListing;
                _db = new CarRentalEntities();
                PopulateFields(carToEdit);
            }
            
        }

        private void PopulateFields(TypesOfCar car)
        {
            tbMaker.Text = car.Maker;
            tbModel.Text = car.Model;
            tbVIN.Text = car.VIN;
            tbYear.Text = car.Year.ToString();
            tbLicencePlateNo.Text = car.LicensePlateNumber;
            lblId.Text = car.Id.ToString();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                if (isEditMode)
                {
                    var id = int.Parse(lblId.Text);
                    var car = _db.TypesOfCars.FirstOrDefault(q => q.Id == id);
                    car.Maker = tbMaker.Text;
                    car.Model = tbModel.Text;
                    car.VIN = tbVIN.Text;
                    car.LicensePlateNumber = tbLicencePlateNo.Text;
                    car.Year = int.Parse(tbYear.Text);


                    _db.SaveChanges();
                    MessageBox.Show("Operation completed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                else
                {
                    //create new object as to add new record:
                    var newCar = new TypesOfCar
                    {
                        Maker = tbMaker.Text,
                        Model = tbModel.Text,
                        VIN = tbVIN.Text,
                        LicensePlateNumber = tbLicencePlateNo.Text,
                        Year = int.Parse(tbYear.Text)
                    };

                    _db.TypesOfCars.Add(newCar);

                    _db.SaveChanges();
                    _manageVehicleListing.PopulateGrid();
                    MessageBox.Show("Operation completed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
