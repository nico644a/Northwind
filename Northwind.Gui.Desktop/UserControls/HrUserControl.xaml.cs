using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Northwind.DataAccess;
using Northwind.Entities;

namespace Northwind.Gui.Desktop.UserControls
{
    /// <summary>
    /// Interaction logic for HrUserControl.xaml
    /// </summary>
    public partial class HrUserControl: UserControl
    {
        public HrUserControl()
        {
            InitializeComponent();
            try
            {
                Repository repository = new Repository();
                List<Employee> employees = repository.GetAllEmployees();
                DataContext = employees;
                dataGridEmployees.ItemsSource = employees;
            }
            catch(Exception)
            {
                MessageBox.Show($"Data kunne desværre ikke hentes. Kontakt en IT medarbejder.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        

        private void ButtonContactinformation_Click(object sender, RoutedEventArgs e)
        {
            var validationResult = ContactInformation.ValidateMail("mara@aspit.dk");
            Employee selectedEmployee = dataGridEmployees.SelectedItem as Employee;
            
                selectedEmployee.ContactInformation.WorkEmail = textBoxWorkEmail.Text;
                selectedEmployee.ContactInformation.WorkPhone = textBoxWorkPhone.Text;
                selectedEmployee.ContactInformation.PrivateEmail = textBoxPrivateEmail.Text;
                selectedEmployee.ContactInformation.PrivatePhone = textBoxPrivatePhone.Text;


            if(selectedEmployee is null)
            {
                Repository repository = new Repository();

                if(selectedEmployee.Id == 0)
                {
                    repository.SaveEContactInformationEmployee(selectedEmployee);
                }
                else
                {
                    repository.UpdateContactInformationEmployee(selectedEmployee);
                }
            }

            else
            {
               MessageBox.Show("error");
            }
        }

        private void ButtonAdress_Click(Object sender, RoutedEventArgs e)
        {
            var validationResult = Address.ValidateStreetNumber("507 - 20th Ave. E.  Apt. 2A");
            Employee selectedEmployee = dataGridEmployees.SelectedItem as Employee;
            selectedEmployee.Address.StreetNumber = textBoxStreetNumber.Text;
            selectedEmployee.Address.City = textBoxCity.Text;
            selectedEmployee.Address.PostalCode = textBoxPostalCode.Text;
            selectedEmployee.Address.Country = textBoxCountry.Text;

            Repository repository = new Repository();

            if(selectedEmployee.Id == 0)
            {
                repository.SaveAdressEmployee(selectedEmployee);
            }
            else
            {
                repository.UpdateAdressEmployee(selectedEmployee);
            }
        }

        public partial class App: Application
        {

            private void Application_Startup(object sender, StartupEventArgs e)
            {
                MainWindow wnd = new MainWindow();
                if(e.Args.Length == 1)
                    MessageBox.Show("Now opening file: \n\n" + e.Args[0]);
                wnd.Show();
            }
        }
    }
}
