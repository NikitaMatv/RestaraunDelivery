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
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
            LBMeal.ItemsSource = App.DB.Meal.ToList();
        }
        public IEnumerable<Meal> meal = App.DB.Meal.ToList();
        private void BtAddInCart_Click(object sender, RoutedEventArgs e)
        {
            var selectedclient = (sender as Button).DataContext as Meal;
            if (selectedclient == null)
            {
                MessageBox.Show("Выберете товар");
                return;
            }
            else
            {
                Order_Meal zakaz = new Order_Meal();
                zakaz.MealID = selectedclient.ID;
                zakaz.Count = 1;
                zakaz.CustomerID = App.LoggedCustomer.ID;
                if (App.DB.Order_Meal.FirstOrDefault(x => x.OrderID == null && x.CustomerID == App.LoggedCustomer.ID && x.MealID == selectedclient.ID) == null)
                {
                    App.DB.Order_Meal.Add(zakaz);
                }
                else
                {
                    var zakazz = App.DB.Order_Meal.FirstOrDefault(x => x.OrderID == null && x.CustomerID == App.LoggedCustomer.ID && x.MealID == selectedclient.ID) as Order_Meal;
                    if (zakazz.Count < 20)
                    {
                        zakazz.Count = zakazz.Count + 1;
                    }
                    else
                    {
                        MessageBox.Show("Одну позицию из меню можно заказать не больше 20 раз в одно заказе!");
                    }
                }
                App.DB.SaveChanges();
                Button bt = sender as Button;
                bt.Visibility = Visibility.Hidden;
            }
        }
        private void Update ()
        { 
            if(TbSearch.Text.Length > 0)
            {
                meal = meal.Where(x => x.Name.ToLower().Contains(TbSearch.Text.Trim().ToLower()));
                LBMeal.ItemsSource = meal.ToList();
            }
            else
            {
                LBMeal.ItemsSource = meal.ToList();
            }
        }
        private void BtFirst_MouseDown(object sender, MouseButtonEventArgs e)
        {
            meal = App.DB.Meal.Where(x=>x.CotegoriesID == 1).ToList();
            Update();
        }
        private void BtSecond_MouseDown(object sender, MouseButtonEventArgs e)
        {
            meal = App.DB.Meal.Where(x => x.CotegoriesID == 2).ToList();
            Update();
        }

        private void BtSalad_MouseDown(object sender, MouseButtonEventArgs e)
        {
            meal = App.DB.Meal.Where(x => x.CotegoriesID == 3).ToList();
            Update();
        }

        private void BtDessert_MouseDown(object sender, MouseButtonEventArgs e)
        {
            meal = App.DB.Meal.Where(x => x.CotegoriesID == 4).ToList();
            Update();
        }

        private void BtDrinks_MouseDown(object sender, MouseButtonEventArgs e)
        {
            meal = App.DB.Meal.Where(x => x.CotegoriesID == 5).ToList();
            Update();
        }

        private void BtAll_MouseDown(object sender, MouseButtonEventArgs e)
        {
            meal = App.DB.Meal.ToList();
            TbSearch.Text = string.Empty;
            Update();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
