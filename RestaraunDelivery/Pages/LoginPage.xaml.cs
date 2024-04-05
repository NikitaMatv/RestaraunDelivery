using RestaraunDelivery.Components;
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

namespace RestaraunDelivery.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void AutorBt_Click(object sender, RoutedEventArgs e)
        {
            var customer = App.DB.Customer.FirstOrDefault(Cus => Cus.Login == LoginTb.Text);
            if (customer == null)
            { 
                MessageBox.Show("Логин неверный");
                return;
            }   
            if (customer.Password != PasswordTb.Password)
            {
                MessageBox.Show("Пароль неверный");
                return;
            }
            if (customer.IsDismissed != true)
            {
                MessageBox.Show("Аккаунт заблокирован. \n Для разблокировки обратитеть в поддержку на почту 'restaraunt.delivery@gmail.co'. \n С уважение команда Restaraunt Delivery.");
                return;
            }
            App.LoggedCustomer = customer;
            NavigationService.Navigate(new MainMenuPage());
        }
        private void RegBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage(new Customer()));
        }

        private void ForgotPassBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ForgotPasswordPage());
        }
    }
}
