using RestaraunDelivery.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace RestaraunDelivery.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        Customer ContextCustomer;
        public RegistrationPage(Customer customer)
        {
            InitializeComponent();
            ContextCustomer = customer;
            DataContext = ContextCustomer;
        }

        private void MainClientBt_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordTb.Text.Trim().Length > 0 && NameTb.Text.Trim().Length > 0 && LoginTb.Text.Trim().Length > 0)
            {
                if (App.DB.Customer.FirstOrDefault(x => x.Login == LoginTb.Text.Trim()) == null)
                {


                    if (ContextCustomer.ID == 0)
                    {
                        App.DB.Customer.Add(ContextCustomer);
                    }
                }
                else
                {
                    MessageBox.Show("Логин уже занят");
                    return;
                }
                App.DB.SaveChanges();
                NavigationService.Navigate(new LoginPage());
            }
            else
            {
                MessageBox.Show("Заполните все обезательные поля");
            }

        }

        private void ExitBt_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new LoginPage());
        }
        private void LoginTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[A-z0-9]") == false)
            {
                e.Handled = true;
            }
        }

        private void NameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[А-я]") == false)
            {
                e.Handled = true;
            }
        }

        private void PhoneNumberTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9]") == false)
            {
                e.Handled = true;
            }
        }
    }
}
