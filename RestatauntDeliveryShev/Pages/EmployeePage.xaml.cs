using RestatauntDeliveryShev.Components;
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

namespace RestatauntDeliveryShev.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();
            LVEmployee.ItemsSource = App.DB.Employee.Where(x => x.RoleID != 1 && x.IsDismissed != true && x.RestaurantID == App.LoggedEmployee.RestaurantID).ToList();
            CbRestaraunt.ItemsSource = App.DB.Restaurant.ToList();
            CbRestaraunt.SelectedIndex = 0;
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditEmployeePage(new Employee()));
        }

        private void Refreh()
        {
            if (string.IsNullOrWhiteSpace(TbSelected.Text))
            {
               LVEmployee.ItemsSource = App.DB.Employee.Where(x => x.RoleID != 1 && x.IsDismissed != true && x.RestaurantID == App.LoggedEmployee.RestaurantID).ToList();                    
            }
            else
            {      
               LVEmployee.ItemsSource = App.DB.Employee.Where(x => x.RoleID != 1 && x.IsDismissed != true && x.RestaurantID == App.LoggedEmployee.RestaurantID).Where(a => a.Name.ToLower().Contains(TbSelected.Text.ToLower()) || a.Surname.ToLower().Contains(TbSelected.Text.ToLower())).ToList();                         
            }

        }


        private void DellBt_Click(object sender, RoutedEventArgs e)
        {
            var selected = (sender as MenuItem).DataContext as Employee;
            if (selected == null)
            {
                MessageBox.Show("Ошбика. Сотрудник не найден.");
                return;
            }
            selected.IsDismissed = true;
            App.DB.SaveChanges();
            MessageBox.Show($"Сотрудник {selected.StrFullName} был уволен");
            Refreh();
        }

        private void EditBt_Click(object sender, RoutedEventArgs e)
        {
            var selected = (sender as MenuItem).DataContext as Employee;
            if (selected == null)
            {
                MessageBox.Show("Ошбика. Сотрудник не найден.");
                return;
            }
            NavigationService.Navigate(new AddEditEmployeePage(selected));
        }

        private void BtAll_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TbSelected.Text = string.Empty;
            CbRestaraunt.SelectedIndex = 0;
            Refreh();
        }

        private void CbRestaraunt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refreh();
        }

        private void TbSelected_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refreh();
        }
    }
}
