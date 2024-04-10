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

namespace RestarauntDeliveryCook.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
            var oreder = App.DB.Order.FirstOrDefault(x => x.EmployeeID == App.LoggedEmployee.ID && x.StatusID == 2);
            if (oreder != null)
            {
                MemuFame.NavigationService.Navigate(new OrderFulfillmentPage(oreder));
            }
            else
            {
                MemuFame.NavigationService.Navigate(new OrderPage());
            }
           
        }

       
        private void BtExit_Click(object sender, RoutedEventArgs e)
        {
            App.IsAutorizate = false;
            App.LoggedEmployee = null;
            NavigationService.Navigate(new LoginPage());
        }

        private void BtMenu_Click(object sender, RoutedEventArgs e)
        {
            MemuFame.NavigationService.Navigate(new OrderPage());
        }

    }
}
