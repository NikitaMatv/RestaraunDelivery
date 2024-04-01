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
using RestaraunDelivery.Components;
namespace RestaraunDelivery.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfileEditingPage.xaml
    /// </summary>
    public partial class ProfileEditingPage : Page
    {
        Customer ContextCustomer;
        public ProfileEditingPage(Customer customer)
        {
            InitializeComponent();
            ContextCustomer = customer;
            DataContext = ContextCustomer;
        }


        private void MainClientBt_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordTb.Text.Trim().Length > 0 && NameTb.Text.Trim().Length > 0 && SurNameTb.Text.Trim().Length > 0)
            {
                if (ContextCustomer.ID == 0)
                {
                    App.DB.Customer.Add(ContextCustomer);
                }
                App.DB.SaveChanges();
                App.LoggedCustomer = ContextCustomer;
                NavigationService.Navigate(new ProfilePage(App.LoggedCustomer));
            }
            else
            {
                MessageBox.Show("Заполните все поля верно");
            }

        }

        private void ExitBt_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new ProfilePage(App.LoggedCustomer));
        }
        private void NameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[А-я]") == false)
            {
                e.Handled = true;
            }
        }

        private void LoginTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[A-z0-9]") == false)
            {
                e.Handled = true;
            }
        }

        private void PhoneTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9]") == false)
            {
                e.Handled = true;
            }
        }
    }
}
