using DatbaseProject.src;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DatbaseProject
{
    /// <summary>
    /// Formulář `CustomerRentalsForm` slouží k zobrazení a správě výpůjček konkrétního zákazníka.
    /// Umožňuje zobrazit výpůjčky, přidávat nové, mazat existující a zajišťuje načítání dat z databáze.
    /// </summary>
    public partial class CustomerRentalsForm : Form
    {
        // ID zákazníka, jehož výpůjčky se zobrazují.
        private readonly int _customerId;

        /// <summary>
        /// Konstruktor formuláře. Inicializuje formulář a nastavuje ID zákazníka.
        /// </summary>
        /// <param name="customerId">ID zákazníka, jehož výpůjčky se mají spravovat.</param>
        public CustomerRentalsForm(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
        }

        /// <summary>
        /// Načte potřebná data při spuštění formuláře.
        /// </summary>
        private void CustomerRentalsForm_Load(object sender, EventArgs e)
        {
            LoadCars(); // Načte dostupná auta pro výpůjčku.
            LoadRentals(); // Načte seznam výpůjček zákazníka.
        }

        /// <summary>
        /// Načte a zobrazí výpůjčky zákazníka. Obsahuje informace o zákazníkovi a půjčeném autě.
        /// </summary>
        private void LoadRentals()
        {
            try
            {
                using (var context = new CarRentalContext())
                {
                    // Načítáme výpůjčky spolu s detaily zákazníka a auta.
                    var rentals = context.Rental
                        .Include(r => r.Customer)
                        .Include(r => r.Car)
                        .Where(r => r.CustomerId == _customerId)
                        .Select(r => new
                        {
                            r.RentalId,
                            CustomerFullName = r.Customer.FirstName + " " + r.Customer.LastName,
                            CarInfo = r.Car.Brand + " " + r.Car.Model + " (" + r.Car.LicensePlate + ")",
                            r.StartDate,
                            r.EndDate,
                            r.TotalPrice
                        })
                        .ToList();

                    // Zobrazení výpůjček v DataGridView.
                    dataGridViewRentals.DataSource = rentals;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při načítání výpůjček: " + ex.Message);
            }
        }

        /// <summary>
        /// Načte seznam aut z databáze a naplní ComboBox pro výběr auta.
        /// </summary>
        private void LoadCars()
        {
            try
            {
                using (var context = new CarRentalContext())
                {
                    // Z databáze si vezmeme seznam aut (jen potřebné sloupce):
                    var cars = context.Car
                                      .Select(c => new
                                      {
                                          c.CarId,
                                          DisplayName = c.Brand + " " + c.Model + " (" + c.LicensePlate + ")"
                                      })
                                      .ToList();

                    // Naplnění ComboBoxu
                    comboCar.DataSource = cars;
                    comboCar.DisplayMember = "DisplayName"; // co uvidí uživatel
                    comboCar.ValueMember = "CarId";          // co se uloží do comboCar.SelectedValue
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při načítání aut: " + ex.Message);
            }
        }

        private void btnAddRental_Click(object sender, EventArgs e)
        {
            DateTime start = dateTimePickerStart.Value;
            DateTime end = dateTimePickerEnd.Value;
            if (!double.TryParse(txtTotalPrice.Text, out double totalPrice))
            {
                MessageBox.Show("Cena musí být platné číslo.", "Chyba vstupu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rental = new Rental
            {
                CustomerId = _customerId,
                CarId = (int)comboCar.SelectedValue,
                StartDate = start,
                EndDate = end,
                TotalPrice = totalPrice
            };

            // Validace rental objektu
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(rental);

            if (!Validator.TryValidateObject(rental, validationContext, validationResults, true))
            {
                var errors = string.Join(Environment.NewLine, validationResults.Select(v => v.ErrorMessage));
                MessageBox.Show("Chyba při validaci:\n" + errors, "Validace", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var context = new CarRentalContext())
                {
                    context.Rental.Add(rental);
                    context.SaveChanges();
                }
                MessageBox.Show("Výpůjčka byla úspěšně přidána.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při přidávání výpůjčky: " + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        /// <summary>
        /// Smaže vybranou výpůjčku z databáze.
        /// </summary>
        private void btnDeleteRental_Click(object sender, EventArgs e)
        {
            if (dataGridViewRentals.SelectedRows.Count == 0)
                return;

            // Získáme ID vybrané výpůjčky.
            int rentalId = (int)dataGridViewRentals
                .SelectedRows[0]
                .Cells["RentalId"]
                .Value;

            try
            {
                using (var context = new CarRentalContext())
                {
                    var rental = context.Rental.Find(rentalId);
                    if (rental != null)
                    {
                        context.Rental.Remove(rental);
                        context.SaveChanges(); // Odstranění výpůjčky z databáze.
                    }
                }
                MessageBox.Show("Výpůjčka smazána.");
                LoadRentals(); // Obnoví seznam výpůjček.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při mazání výpůjčky: " + ex.Message);
            }
        }
    }
}