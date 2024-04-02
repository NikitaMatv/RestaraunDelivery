using RestarauntDeliveryAdministrator.Components;
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
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();
                LVEmployee.ItemsSource = App.DB.Employee.Where(x => x.RoleID != 1).ToList();
                //AddBt.Visibility = Visibility.Visible;
                //RedBr.Visibility = Visibility.Visible;
                //DelBt.Visibility = Visibility.Visible;
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new EmployeeAddEdintPages(new Employee()));
        }

        private void RedBr_Click(object sender, RoutedEventArgs e)
        {
            var selectedorder = LVEmployee.SelectedItem as Employee;
            if (selectedorder == null)
            {
                MessageBox.Show("Выберете сотрудника");
                return;
            }
            //NavigationService.Navigate(new EmployeeAddEdintPages(selectedorder));
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refreh();
        }
        private void Refreh()
        {
            if (string.IsNullOrWhiteSpace(TbSelected.Text))
            {
                LVEmployee.ItemsSource = App.DB.Employee.Where(x => x.RoleID != 1).ToList();
            }
            else
            {
                LVEmployee.ItemsSource = App.DB.Employee.Where(x => x.RoleID != 1).Where(a => a.Name.ToLower().Contains(TbSelected.Text.ToLower()) || a.Surname.ToLower().Contains(TbSelected.Text.ToLower())).ToList();
            }

        }
       
        private void TbSelected_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refreh();
        }

        private void DelBt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DellBt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBt_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
