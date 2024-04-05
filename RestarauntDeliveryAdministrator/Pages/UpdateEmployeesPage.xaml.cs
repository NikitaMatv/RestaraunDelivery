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
    /// Логика взаимодействия для UpdateEmployeesPage.xaml
    /// </summary>
    public partial class UpdateEmployeesPage : Page
    {
        public UpdateEmployeesPage()
        {
            InitializeComponent();
            LVEmployee.ItemsSource = App.DB.Employee.Where(x => x.RoleID != 1 && x.IsDismissed == true).ToList();      
        }      
        private void Refreh()
        {
            if (string.IsNullOrWhiteSpace(TbSelected.Text))
            {
                LVEmployee.ItemsSource = App.DB.Employee.Where(x => x.RoleID != 1 && x.IsDismissed == true).ToList();
            }
            else
            {             
                LVEmployee.ItemsSource = App.DB.Employee.Where(x => x.RoleID != 1 && x.IsDismissed == true).Where(a => a.Name.ToLower().Contains(TbSelected.Text.ToLower()) || a.Surname.ToLower().Contains(TbSelected.Text.ToLower())).ToList();             
            }

        }


        private void BtAll_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TbSelected.Text = string.Empty;
            Refreh();
        }
     
        private void TbSelected_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refreh();
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            var selected = (sender as MenuItem).DataContext as Employee;
            if (selected == null)
            {
                MessageBox.Show("Ошбика. Сотрудник не найден.");
                return;
            }
            MessageBox.Show("Для восстановления сотрудники проверьте корректность данных о нем.");
            NavigationService.Navigate(new AddEditEmployeePage(selected));
        }
    }
}
