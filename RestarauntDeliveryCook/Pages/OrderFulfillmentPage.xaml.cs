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
    /// Логика взаимодействия для OrderFulfillmentPage.xaml
    /// </summary>
    public partial class OrderFulfillmentPage : Page
    {
        public IEnumerable<Order_Meal> order_mealsList;
        Order conetextOrder_Meal;
       
        public OrderFulfillmentPage(Order order)
        {
            InitializeComponent();
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();      
            conetextOrder_Meal = order;
            DataContext = conetextOrder_Meal;
            LBMeal.ItemsSource = conetextOrder_Meal.Order_Meal.ToList();
            order_mealsList = conetextOrder_Meal.Order_Meal.ToList();
            if(conetextOrder_Meal.StatusID == 2)
            {
                AcceptBt.Visibility = Visibility.Collapsed;
                ComplBt.Visibility = Visibility.Visible;
            }
        }
        private void Update()
        {
            if (TbSearch.Text.Length > 0)
            {
                order_mealsList = order_mealsList.Where(x => x.Meal.Name.ToLower().Contains(TbSearch.Text.Trim().ToLower()));
                LBMeal.ItemsSource = order_mealsList.ToList();
            }
            else
            {
                LBMeal.ItemsSource = order_mealsList.ToList();
            }
            order_mealsList = conetextOrder_Meal.Order_Meal.ToList();
        }
        private void BtFirst_MouseDown(object sender, MouseButtonEventArgs e)
        {
            order_mealsList = conetextOrder_Meal.Order_Meal.Where(x => x.Meal.CotegoriesID == 1).ToList();
            Update();
        }
        private void BtSecond_MouseDown(object sender, MouseButtonEventArgs e)
        {
            order_mealsList = conetextOrder_Meal.Order_Meal.Where(x => x.Meal.CotegoriesID == 2).ToList();
            Update();
        }

        private void BtSalad_MouseDown(object sender, MouseButtonEventArgs e)
        {
            order_mealsList = conetextOrder_Meal.Order_Meal.Where(x => x.Meal.CotegoriesID == 3).ToList();
            Update();
        }

        private void BtDessert_MouseDown(object sender, MouseButtonEventArgs e)
        {
            order_mealsList = conetextOrder_Meal.Order_Meal.Where(x => x.Meal.CotegoriesID == 4).ToList();
            Update();
        }

        private void BtDrinks_MouseDown(object sender, MouseButtonEventArgs e)
        {
            order_mealsList = conetextOrder_Meal.Order_Meal.Where(x => x.Meal.CotegoriesID == 5).ToList();
            Update();
        }

        private void BtAll_MouseDown(object sender, MouseButtonEventArgs e)
        {
            order_mealsList = conetextOrder_Meal.Order_Meal.ToList();
            TbSearch.Text = string.Empty;
            Update();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void AcceptBt_Click(object sender, RoutedEventArgs e)
        {
            conetextOrder_Meal.StatusID = 2;
            conetextOrder_Meal.EmployeeID = App.LoggedEmployee.ID;
            App.DB.SaveChanges();
            AcceptBt.Visibility = Visibility.Collapsed;
            ComplBt.Visibility = Visibility.Visible;
        }

        private void ComplBt_Click(object sender, RoutedEventArgs e)
        {
            conetextOrder_Meal.StatusID = 3;
            App.DB.SaveChanges();
            NavigationService.Navigate(new OrderPage());
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var dataorder = conetextOrder_Meal.DateTimes;
            TimeSpan timer = (TimeSpan)(dataorder - DateTime.Now);

            TbTime.Text = timer.ToString();


            CommandManager.InvalidateRequerySuggested();
        }
    }
}
