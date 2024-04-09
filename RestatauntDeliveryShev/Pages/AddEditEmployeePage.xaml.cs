using RestatauntDeliveryShev.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddEditEmployeePage.xaml
    /// </summary>
    public partial class AddEditEmployeePage : Page
    {
        Employee ContextEmployee;
        public AddEditEmployeePage(Employee employee)
        {
            InitializeComponent();
            ContextEmployee = employee;
            DataContext = ContextEmployee;
            CbRole.ItemsSource = App.DB.EmployeeRole.Where(x => x.ID == 4).ToList();
            CbAddres.ItemsSource = App.DB.Restaurant.Where(x => x.ID == App.LoggedEmployee.RestaurantID).ToList();
            if (ContextEmployee.ID == 0)
            {
                LoginTb.IsReadOnly = false;
            }
        }


        private void MainClientBt_Click(object sender, RoutedEventArgs e)
        {
            if (NameTb.Text.Trim().Length > 0 && SurNameTb.Text.Trim().Length > 0 && LoginTb.Text.Trim().Length > 0 && PhoneTb.Text.Trim().Length > 0)
            {
                if (!Regex.IsMatch(ContextEmployee.Email, @"^[\w_.]+@([\w][-\w]?[\w]+\.)+[A-Za-z]{2,4}$"))
                {
                    MessageBox.Show("Некорректный email");
                    return;
                }
                ContextEmployee.IsDismissed = false;
                if (ContextEmployee.ID == 0)
                {
                    ContextEmployee.Password = GenerateLoginPassword();
                    App.DB.Employee.Add(ContextEmployee);
                }
                App.DB.SaveChanges();
                NavigationService.Navigate(new EmployeePage());
            }
            else
            {
                MessageBox.Show("Заполните все поля верно");
            }

        }
        private string GenerateLoginPassword()
        {
            int length = 8;

            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random random = new Random();
            while (0 < length--)
            {
                res.Append(valid[random.Next(valid.Length)]);
            }
            Clipboard.SetText(res.ToString());
            return res.ToString();

        }

        private void ExitBt_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new EmployeePage());
        }
        private void NameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[А-я]") == false)
            {
                e.Handled = true;
            }
        }

        private void LoginTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[A-z0-9]") == false)
            {
                e.Handled = true;
            }
        }

        private void PhoneTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9]") == false)
            {
                e.Handled = true;
            }
        }
    }
}
