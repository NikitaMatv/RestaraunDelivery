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
    /// Логика взаимодействия для DetailsOrderPage.xaml
    /// </summary>
    public partial class DetailsOrderPage : Page
    {
        public IEnumerable<Order_Meal> order_mealsList;
        Order conetextOrder_Meal;
        public DetailsOrderPage(Order order_meal)
        {
            InitializeComponent();
            conetextOrder_Meal = order_meal;
            DataContext = conetextOrder_Meal;
            LBMeal.ItemsSource = conetextOrder_Meal.Order_Meal.ToList();
            order_mealsList = conetextOrder_Meal.Order_Meal.ToList();
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
            order_mealsList = conetextOrder_Meal.Order_Meal.Where(x=>x.Meal.CotegoriesID == 1).ToList();
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
    }
}
