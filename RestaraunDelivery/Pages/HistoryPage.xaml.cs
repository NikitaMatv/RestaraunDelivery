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
    /// Логика взаимодействия для HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
           

        public HistoryPage()
        {
            InitializeComponent();

            LbCart.ItemsSource = App.DB.Order.Where(x => x.Order_Meal.FirstOrDefault(z => z.CustomerID == App.LoggedCustomer.ID) != null).ToList();
        }
        private void BtDetails_Click(object sender, RoutedEventArgs e)
        {
            var meal = (sender as MenuItem).DataContext as Order;
            NavigationService.Navigate(new DetailsOrderPage(meal));
           
        }

    }
}
