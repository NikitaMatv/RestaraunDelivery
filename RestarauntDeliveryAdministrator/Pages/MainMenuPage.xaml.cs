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

namespace RestarauntDeliveryAdministrator.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
            MemuFame.NavigationService.Navigate(new MenuPage());
        }

        private void BtHistory_Click(object sender, RoutedEventArgs e)
        {
            MemuFame.NavigationService.Navigate(new UpdateEmployeesPage());
        }

        private void BtExit_Click(object sender, RoutedEventArgs e)
        {
            App.IsAutorizate = false;
            App.LoggedEmployee = null;
            NavigationService.Navigate(new LoginPage());
        }
    
        private void BtCart_Click(object sender, RoutedEventArgs e)
        {
            MemuFame.NavigationService.Navigate(new EmployeePage());
        }

        private void BtMenu_Click(object sender, RoutedEventArgs e)
        {
            MemuFame.NavigationService.Navigate(new MenuPage());
        }

        private void BtCustomer_Click(object sender, RoutedEventArgs e)
        {
            MemuFame.NavigationService.Navigate(new CusomerPage());
        }
    }
}
