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
    public partial class AddRentalRecord : Form
    {
        private readonly CarRentalEntities carRentalEntities;
        public bool isEditMode;
        public AddRentalRecord()
        {
            InitializeComponent();
            carRentalEntities = new CarRentalEntities();
            lblTitleRentalRecords.Text = "Add Rental Record";
            this.Text = "Add Rental Record";
            isEditMode = false;
        }

        public AddRentalRecord(CarRentalRecord rentalRecord)
        {
            InitializeComponent();

            if(rentalRecord == null)
            {
                MessageBox.Show("Please ensure that you selected a valid record to edit");
            }
            else
            {
                lblTitleRentalRecords.Text = "Edit Rental Record";
                this.Text = "Add Rental Record";
                isEditMode = true;
                carRentalEntities = new CarRentalEntities();
                PopulateFields(rentalRecord);
            }
        }

        private void PopulateFields(CarRentalRecord rentalRecord)
        {
            tCustName.Text = rentalRecord.CustomerName;
            tCost.Text = rentalRecord.Cost.ToString();
            dtRented.Value = (DateTime)rentalRecord.DateRented;
            dtReturned.Value = (DateTime)rentalRecord.DateReturned;
            lblId.Text = rentalRecord.id.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var cars = carRentalEntities.TypesOfCars.ToList();

            var cars = carRentalEntities.TypesOfCars
                        .Select(q => new { Id = q.Id, Name = q.Maker + " " + q.Model }).ToList();
            cboCarType.DisplayMember = "Name";
            cboCarType.ValueMember = "id";
            cboCarType.DataSource = cars;
            dtReturned.Value = dtRented.Value + TimeSpan.FromDays(7);
        }

        private void dtReturned_ValueChanged(object sender, EventArgs e)
        {
            if (dtReturned.Value < dtRented.Value)
            {
                MessageBox.Show("Date returned should be greater than date rented");
                dtReturned.Value = dtRented.Value + TimeSpan.FromDays(7);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(tCustName.Text) || cboCarType.SelectedIndex == -1 || tCost.Text == "")
                {
                    MessageBox.Show("Please enter missing data!");
                }
                else
                {
                    var rentalRecord = new CarRentalRecord();
                    if (isEditMode)
                    {
                        var id = int.Parse(lblId.Text);
                        rentalRecord = carRentalEntities.CarRentalRecords
                                     .FirstOrDefault(q => q.id == id);
                    }

                    rentalRecord.CustomerName = tCustName.Text;
                    rentalRecord.Cost = decimal.Parse(tCost.Text);
                    rentalRecord.DateRented = dtRented.Value;
                    rentalRecord.DateReturned = dtReturned.Value;
                    rentalRecord.TypeOfCarId = Convert.ToInt32(cboCarType.SelectedValue);


                    if(!isEditMode)
                    
                         carRentalEntities.CarRentalRecords.Add(rentalRecord);

                    carRentalEntities.SaveChanges();

                        var selectedCar = cboCarType.Text;


                        MessageBox.Show($"Thank you for renting {tCustName.Text}\n\r"
                                    + $"please return {selectedCar}\n\r"
                                    + $"by {dtReturned.Value.ToShortDateString()}\n\r"
                                    + $"Cost Rp {tCost.Text}");
                    

                    this.Close();
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
            
        }


    }
}
