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
    /// Логика взаимодействия для BasketPage.xaml
    /// </summary>
    public partial class BasketPage : Page
    {
        public BasketPage()
        {
            InitializeComponent();
            SpDeliverer.Visibility = Visibility.Collapsed;
            LbCart.ItemsSource = App.DB.Order_Meal.Where(x => x.CustomerID == App.LoggedCustomer.ID && x.OrderID == null).ToList();
            int pri = 0;
            IEnumerable<Order_Meal> products = App.DB.Order_Meal.Where(x => x.OrderID == null && x.CustomerID == App.LoggedCustomer.ID).ToList();
            foreach (var items in products)
            {
                pri += (int)items.Meal.Price * (int)items.Count;
            }
            TbPrice.Text = pri.ToString();
            if (LbCart.Items.Count == 0)
            {
                BtZakaz.Visibility = Visibility.Hidden;
            }
            CbRestauran.ItemsSource = App.DB.Restaurant.ToList();
            CbRestauran.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedclient = (sender as Button).DataContext as Order_Meal;
            if (selectedclient.Count > 1)
            {
                selectedclient.Count = selectedclient.Count - 1;
            }
            else
            {
                App.DB.Order_Meal.Remove(selectedclient);
            }
            App.DB.SaveChanges();
            NavigationService.Navigate(new BasketPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var selectedclient = (sender as Button).DataContext as Order_Meal;
            App.DB.Order_Meal.Remove(selectedclient);
            App.DB.SaveChanges();
            NavigationService.Navigate(new BasketPage());
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var selectedclient = (sender as Button).DataContext as Order_Meal;
            if (selectedclient.Count < 20)
            {
                selectedclient.Count = selectedclient.Count + 1;
            }
            else
            {
                MessageBox.Show("Можно заказать тока 20 шт");
                return;
            }
            App.DB.SaveChanges();
            NavigationService.Navigate(new BasketPage());
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Order zakaz = new Order();
            zakaz.Price = int.Parse(TbPrice.Text);
            zakaz.DateTime = DateTime.Now;
            zakaz.Address = TbAddress.Text;
            zakaz.StatusID = 1;
            if(CbDeliverer.IsChecked == true)
            {
                zakaz.OptionsID = 2;
            }
            else
            {
                zakaz.OptionsID = 1;
                zakaz.RestaurantID = CbRestauran.SelectedIndex +1;
            }
            Random rand = new Random();
            zakaz.Code = rand.Next(100000, 999999);
            App.DB.Order.Add(zakaz);
            App.DB.SaveChanges();
            IEnumerable<Order_Meal> products = App.DB.Order_Meal.Where(x => x.OrderID == null && x.CustomerID == App.LoggedCustomer.ID).ToList();
            foreach (var items in products)
            {
                items.OrderID = zakaz.ID;
            }
            App.DB.SaveChanges();
            if(CbDeliverer.IsChecked == false)
            {
                MessageBox.Show($"Заказ № {zakaz.ID} оформлен.\n Закакз будет готов к {DateTime.Now.AddMinutes(40).ToString("HH:mm")}. \n Контактный телефон: +7 (843) 279-58-23  \n Код заказа {zakaz.Code}. ");
            }
            else
            {
                MessageBox.Show($"Заказ № {zakaz.ID} оформлен.\n Закакз будет готов к {DateTime.Now.AddMinutes(90).ToString("HH:mm")}. \n Будет доставлено по адресу {zakaz.Address} \n Контактный телефон: +7 (843) 279-58-23   \n Код заказа {zakaz.Code}. ");
            }
            NavigationService.Navigate(new BasketPage());
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if(CbDeliverer.IsChecked == true)
            {
                SpDeliverer.Visibility = Visibility.Visible;
                SpRestauraun.Visibility = Visibility.Collapsed;
                CbRestauran.SelectedIndex = 0;
            }
            if (CbDeliverer.IsChecked == false)
            {
                SpDeliverer.Visibility = Visibility.Collapsed;
                SpRestauraun.Visibility = Visibility.Visible;
                TbAddress.Text = string.Empty;
                CbRestauran.SelectedIndex = 0;
            }
        }
    }
}
