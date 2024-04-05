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
    /// Логика взаимодействия для CusomerPage.xaml
    /// </summary>
    public partial class CusomerPage : Page
    {
        public CusomerPage()
        {
            InitializeComponent();
            LVCustomer.ItemsSource = App.DB.Customer.Where(x =>x.IsDismissed != true).ToList();
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
                if (CbRestaraunt.SelectedIndex == 0)
                {
                    LVCustomer.ItemsSource = App.DB.Customer.Where(x =>x.IsDismissed != true).ToList();
                }
                else
                {               
                        LVCustomer.ItemsSource = App.DB.Customer.Where(x => x.IsDismissed == true).ToList();  
                }
            }
            else
            {
                if (CbRestaraunt.SelectedIndex == 0)
                {
                    LVCustomer.ItemsSource = App.DB.Customer.Where(x =>x.IsDismissed != true).Where(a => a.FirstName.ToLower().Contains(TbSelected.Text.ToLower()) || a.SurName.ToLower().Contains(TbSelected.Text.ToLower())).ToList();
                }
                else
                {
                    LVCustomer.ItemsSource = App.DB.Customer.Where(x =>x.IsDismissed == true).Where(a => a.FirstName.ToLower().Contains(TbSelected.Text.ToLower()) || a.SurName.ToLower().Contains(TbSelected.Text.ToLower())).ToList();
                }

            }

        }


        private void DellBt_Click(object sender, RoutedEventArgs e)
        {
            var selected = (sender as MenuItem).DataContext as Customer;
            if (selected == null)
            {
                MessageBox.Show("Ошбика. Клиент не найден.");
                return;
            }
            selected.IsDismissed = true;
            App.DB.SaveChanges();
            MessageBox.Show($"Клиент {selected.StrFullName} был заблокирован");
            Refreh();
        }

        private void EditBt_Click(object sender, RoutedEventArgs e)
        {
            var selected = (sender as MenuItem).DataContext as Customer;
            if (selected == null)
            {
                MessageBox.Show("Ошбика. Клиент не найден.");
                return;
            }
            selected.IsDismissed = false;
            App.DB.SaveChanges();
            MessageBox.Show($"Клиент {selected.StrFullName} был разблокирован");
            Refreh();
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
