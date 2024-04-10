using RestarauntDeliveryCook.Components;
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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 30);
            dispatcherTimer.Start();
            LbCart.ItemsSource = App.DB.Order.Where(x => x.Order_Meal.FirstOrDefault(z => z.CustomerID != null) != null && x.EmployeeID == null && x.StatusID == 1).ToList();
            var oreder = App.DB.Order.FirstOrDefault(x => x.EmployeeID == App.LoggedEmployee.ID && x.StatusID == 2);
            if (oreder != null)
            {
               NavigationService.Navigate(new OrderFulfillmentPage(oreder));
            }       
        }
        private void BtDetails_Click(object sender, RoutedEventArgs e)
        {
            var orede = (sender as MenuItem).DataContext as Order;
            NavigationService.Navigate(new OrderFulfillmentPage(orede));

        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            LbCart.ItemsSource = App.DB.Order.Where(x => x.Order_Meal.FirstOrDefault(z => z.CustomerID != null) != null && x.EmployeeID == null && x.StatusID == 1).ToList();       
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
