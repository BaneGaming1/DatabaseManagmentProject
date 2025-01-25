using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatbaseProject.src;

namespace DatbaseProject
{
    /// <summary>
    /// Třída `CustomerForm` reprezentuje hlavní uživatelské rozhraní aplikace.
    /// Obsahuje funkce pro správu zákazníků, výpůjček, generování reportů a import dat.
    /// </summary>
    public partial class CustomerForm : Form
    {
        /// <summary>
        /// Konstruktor inicializuje komponenty formuláře.
        /// </summary>
        public CustomerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Načte seznam zákazníků z databáze a zobrazí je v DataGridView.
        /// </summary>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        /// <summary>
        /// Vytvoří nového zákazníka na základě údajů z formuláře a uloží ho do databáze.
        /// </summary>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new CarRentalContext())
                {
                    // Zkontrolujeme, zda e-mail již existuje
                    if (context.Customer.Any(c => c.Email == txtEmail.Text))
                    {
                        MessageBox.Show("Zákazník s tímto e-mailem již existuje.", "Duplicitní e-mail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var customer = new Customer
                    {
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Email = txtEmail.Text,
                        DateOfBirth = dtpDateOfBirth.Value,
                        IsActive = chkIsActive.Checked
                    };

                    // Validace zákazníka
                    var validationResults = new List<ValidationResult>();
                    var validationContext = new ValidationContext(customer);

                    if (!Validator.TryValidateObject(customer, validationContext, validationResults, true))
                    {
                        var errors = string.Join(Environment.NewLine, validationResults.Select(v => v.ErrorMessage));
                        MessageBox.Show("Chyba při validaci:\n" + errors, "Validace", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Uložíme zákazníka do databáze
                    context.Customer.Add(customer);
                    context.SaveChanges();
                }

                MessageBox.Show("Zákazník vytvořen.");
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při vytváření záznamu: " + ex.Message);
            }
        }



        /// <summary>
        /// Upraví existujícího zákazníka na základě údajů z formuláře.
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vyberte zákazníka k úpravě.");
                return;
            }

            int customerId = (int)dataGridViewCustomers
                .SelectedRows[0]
                .Cells["CustomerId"]
                .Value;

            try
            {
                using (var context = new CarRentalContext())
                {
                    var customer = context.Customer.Find(customerId);
                    if (customer != null)
                    {
                        // Kontrola duplicitního e-mailu (ignoruje aktuálního zákazníka)
                        if (context.Customer.Any(c => c.Email == txtEmail.Text && c.CustomerId != customerId))
                        {
                            MessageBox.Show("Zákazník s tímto e-mailem již existuje.", "Duplicitní e-mail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        customer.FirstName = txtFirstName.Text;
                        customer.LastName = txtLastName.Text;
                        customer.Email = txtEmail.Text;
                        customer.DateOfBirth = dtpDateOfBirth.Value;
                        customer.IsActive = chkIsActive.Checked;

                        // Validace zákazníka
                        var validationResults = new List<ValidationResult>();
                        var validationContext = new ValidationContext(customer);

                        if (!Validator.TryValidateObject(customer, validationContext, validationResults, true))
                        {
                            var errors = string.Join(Environment.NewLine, validationResults.Select(v => v.ErrorMessage));
                            MessageBox.Show("Chyba při validaci:\n" + errors, "Validace", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        context.SaveChanges();
                        MessageBox.Show("Záznam upraven.");
                        LoadCustomers();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při úpravě záznamu: " + ex.Message);
            }
        }



        /// <summary>
        /// Smaže vybraného zákazníka z databáze.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count == 0)
            {
                return;
            }

            int customerId = (int)dataGridViewCustomers
                .SelectedRows[0]
                .Cells["CustomerId"]
                .Value;

            try
            {
                using (var context = new CarRentalContext())
                {
                    var customer = context.Customer.Find(customerId);
                    if (customer != null)
                    {
                        // Odstranit
                        context.Customer.Remove(customer);
                        context.SaveChanges(); // DELETE
                    }
                }
                MessageBox.Show("Zákazník smazán.");
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při mazání záznamu: " + ex.Message);
            }
        }

        /// <summary>
        /// Naplní formulář údaji o vybraném zákazníkovi z DataGridView.
        /// </summary>
        private void dataGridViewCustomers_SelectionChanged(object sender, EventArgs e)
        {
            // Naplníme TextBoxy hodnotami z vybraného řádku
            if (dataGridViewCustomers.SelectedRows.Count == 0)
                return;

            var row = dataGridViewCustomers.SelectedRows[0];
            txtFirstName.Text = row.Cells["FirstName"].Value?.ToString();
            txtLastName.Text = row.Cells["LastName"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();

            if (row.Cells["DateOfBirth"].Value is DateTime dob)
            {
                dtpDateOfBirth.Value = dob;
            }

            if (row.Cells["IsActive"].Value is bool active)
            {
                chkIsActive.Checked = active;
            }
        }

        /// <summary>
        /// Načte seznam zákazníků a zobrazí je v DataGridView.
        /// </summary>
        private void LoadCustomers()
        {
            try
            {
                using (var context = new CarRentalContext())
                {
                    var list = context.Customer.ToList();
                    dataGridViewCustomers.DataSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při načítání: " + ex.Message);
            }
        }

        /// <summary>
        /// Otevře nový formulář pro zobrazení a správu výpůjček vybraného zákazníka.
        /// </summary>
        private void btnShowRentals_Click(object sender, EventArgs e)
        {
            // Zkontrolujeme, zda je vybraný řádek v datagridView
            if (dataGridViewCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vyberte zákazníka z tabulky.");
                return;
            }

            // Získáme ID vybraného zákazníka
            int customerId = (int)dataGridViewCustomers
                .SelectedRows[0]
                .Cells["CustomerId"]
                .Value;

            // Otevře nový formulář
            var rentalsForm = new CustomerRentalsForm(customerId);
            rentalsForm.ShowDialog(); // nebo .Show() podle potřeby
        }

        /// <summary>
        /// Vygeneruje souhrnný report o zákaznících, autech a výpůjčkách.
        /// Umožní uložení reportu do souboru.
        /// </summary>
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new CarRentalContext())
                {
                    // 1) Zákazníci
                    int totalCustomers = context.Customer.Count();                  // Celkový počet
                    int activeCustomers = context.Customer.Count(c => c.IsActive); // Počet aktivních

                    // 2) Auta
                    int totalCars = context.Car.Count();                           // Počet aut
                    double minRate = context.Car.Min(c => c.DailyRate);            // Minimální DailyRate
                    double maxRate = context.Car.Max(c => c.DailyRate);            // Maximální DailyRate

                    // 3) Výpůjčky
                    int totalRentals = context.Rental.Count();                     // Počet všech výpůjček
                    double sumPrice = context.Rental.Sum(r => r.TotalPrice);       // Součet cen všech výpůjček
                    double averagePrice = 0;
                    if (totalRentals > 0)
                    {
                        averagePrice = context.Rental.Average(r => r.TotalPrice); // Průměrná cena výpůjčky
                    }

                    // 4) Vytvoříme text reportu
                    var reportBuilder = new StringBuilder();
                    reportBuilder.AppendLine("===== REPORT =====");
                    reportBuilder.AppendLine($"Počet zákazníků:            {totalCustomers}");
                    reportBuilder.AppendLine($"Počet aktivních zákazníků:  {activeCustomers}");
                    reportBuilder.AppendLine($"Počet aut:                  {totalCars}");
                    reportBuilder.AppendLine($"  - Nejlevnější auto:       {minRate} /den");
                    reportBuilder.AppendLine($"  - Nejdražší auto:         {maxRate} /den");
                    reportBuilder.AppendLine($"Počet výpůjček:             {totalRentals}");
                    reportBuilder.AppendLine($"  - Celková cena:           {sumPrice}");
                    reportBuilder.AppendLine($"  - Průměrná cena:          {averagePrice:F2}");

                    // 5) Uložení reportu přes SaveFileDialog
                    using (var sfd = new SaveFileDialog())
                    {
                        sfd.Filter = "Text Files|*.txt|All Files|*.*";
                        sfd.Title = "Ulož report jako...";

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            // Uložení do vybraného souboru
                            System.IO.File.WriteAllText(sfd.FileName, reportBuilder.ToString());

                            // Zobrazení zprávy o uložení
                            MessageBox.Show($"Report uložen do souboru:\n{sfd.FileName}",
                                "Uložení reportu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                    MessageBox.Show(reportBuilder.ToString(),
                        "Souhrnný Report",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při generování reportu: " + ex.Message);
            }
        }

        /// <summary>
        /// Importuje data o autech z CSV souboru.
        /// </summary>
        private void btnImportCars_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV files|*.csv|All files|*.*";
                ofd.Title = "Vyberte CSV soubor pro import aut (Car)";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ImportCarsFromCsv(ofd.FileName);

                        MessageBox.Show("Import aut proběhl úspěšně.",
                            "Import Cars",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        LoadCustomers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chyba při importu aut: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Importuje data o zákaznících z CSV souboru.
        /// </summary>
        private void btnImportCustomers_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV files|*.csv|All files|*.*";
                ofd.Title = "Vyberte CSV soubor pro import zákazníků (Customer)";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ImportCustomersFromCsv(ofd.FileName);

                        MessageBox.Show("Import zákazníků proběhl úspěšně.",
                            "Import Customers",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // Obnovíme zobrazení (voláme LoadCustomers()).
                        LoadCustomers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chyba při importu zákazníků: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Načte data o autech z CSV souboru a uloží je do databáze.
        /// </summary>
        private void ImportCarsFromCsv(string filePath)
        {
            // Přečteme všechny řádky CSV
            var lines = System.IO.File.ReadAllLines(filePath);

            using (var context = new CarRentalContext())
            {
                foreach (var line in lines)
                {
                    // Rozdělíme řádku podle čárky
                    var parts = line.Split(',');

                    if (parts.Length < 5)
                        throw new Exception("Nesprávný formát CSV pro Car. Očekáváme 5 sloupců.");

                    // Naparsujeme data
                    string licensePlate = parts[0].Trim();
                    string brand = parts[1].Trim();
                    string model = parts[2].Trim();

                    // Místo int.Parse(...) uložíme do CarTypeEnum
                    CarTypeEnum carTypeEnum = (CarTypeEnum)int.Parse(parts[3]);

                    double dailyRate = double.Parse(parts[4]);

                    // Vytvoříme novou entitu Car
                    var car = new Car
                    {
                        LicensePlate = licensePlate,
                        Brand = brand,
                        Model = model,
                        CarType = carTypeEnum,  // <- enum místo int
                        DailyRate = dailyRate
                    };

                    // Přidáme do kontextu
                    context.Car.Add(car);
                }
                // Uložíme všechny najednou
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Načte data o zákaznících z CSV souboru a uloží je do databáze.
        /// </summary>
        private void ImportCustomersFromCsv(string filePath)
        {
            var lines = System.IO.File.ReadAllLines(filePath);

            using (var context = new CarRentalContext())
            {
                foreach (var line in lines)
                {
                    var parts = line.Split(',');

                    if (parts.Length < 5)
                        throw new Exception("Nesprávný formát CSV pro Customer. Očekáváme 5 sloupců.");

                    string firstName = parts[0].Trim();
                    string lastName = parts[1].Trim();
                    string email = parts[2].Trim();
                    DateTime dateOfBirth = DateTime.Parse(parts[3]);
                    bool isActive = bool.Parse(parts[4]);

                    var customer = new Customer
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        DateOfBirth = dateOfBirth,
                        IsActive = isActive
                    };

                    context.Customer.Add(customer);
                }
                context.SaveChanges();
            }
        }
    }
}
