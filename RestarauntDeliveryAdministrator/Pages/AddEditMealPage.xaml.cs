﻿using Microsoft.Win32;
using RestarauntDeliveryAdministrator.Components;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace RestarauntDeliveryAdministrator.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditMealPage.xaml
    /// </summary>
    public partial class AddEditMealPage : Page
    {
        Meal contextmeal;
        public AddEditMealPage(Meal meal)
        {
            InitializeComponent();
            CbCotegories.ItemsSource = App.DB.Cotegories.ToList();
            contextmeal = meal;
            DataContext = contextmeal;
        }

        private void BtImage_Click(object sender, RoutedEventArgs e)
        {         
                var dialog = new OpenFileDialog();
                if (dialog.ShowDialog().GetValueOrDefault())
                {
                    contextmeal.Images = File.ReadAllBytes(dialog.FileName);
                    DataContext = null;
                    DataContext = contextmeal;
                }         
        }     

        private void TbName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[A-zА-я]") == false)
            {
                e.Handled = true;
            }
        }

        private void TbPhone_number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9]") == false)
            {
                e.Handled = true;
            }
        }
       
        private void ExitBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }

        private void SaveBt_Click(object sender, RoutedEventArgs e)
        {
            if (contextmeal.Description.Trim() == string.Empty)
            {
                MessageBox.Show("Заполните описание.");
                return;
            }
            if(contextmeal.Name.Trim() == string.Empty)
            {
                MessageBox.Show("Заполните название.");
                return;
            }
            if (contextmeal.Images == null)
            {
                MessageBox.Show("Заполните фотогравию.");
                return;
            }
            if (contextmeal.CotegoriesID == null)
            {
                MessageBox.Show("Выбирите категорию.");
                return;
            }
            if (contextmeal.Price == null)
            {
                MessageBox.Show("Заполните цена.");
                return;
            }
            if(contextmeal.ID == 0)
            {
                App.DB.Meal.Add(contextmeal);
            }
            App.DB.SaveChanges();
            NavigationService.Navigate(new MenuPage());
        }
    }
}
