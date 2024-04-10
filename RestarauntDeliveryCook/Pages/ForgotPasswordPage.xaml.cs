﻿using RestarauntDeliveryCook.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace RestarauntDeliveryCook.Pages
{
    /// <summary>
    /// Логика взаимодействия для ForgotPasswordPage.xaml
    /// </summary>
    public partial class ForgotPasswordPage : Page
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string GeneratedCode { get; set; }
        public Random rnd = new Random();
        public ForgotPasswordPage()
        {
            InitializeComponent();
            DataContext = this;
        }


        private void BGetCode_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(Email, @"^[\w_.]+@([\w][-\w]?[\w]+\.)+[A-Za-z]{2,4}$"))
            {
                MessageBox.Show("Некорректный email");
                return;
            }

            SpCode.Visibility = Visibility.Visible;

            MailSendService mailSend = new MailSendService();
            GeneratedCode = rnd.Next(100000, 999999).ToString();
            string userName = $"{App.DB.Employee.FirstOrDefault(x => x.Email == TbEmail.Text).StrFullName}";
            string body = $@"{ReadResource()
                                .Replace("{name}", userName)
                                .Replace("{code}", GeneratedCode)}";

            var mail = mailSend
                .CreateMail("", "restaraunt.delivery@gmail.com", $"{Email}", "Сброс пароля", body);

            mailSend.SendMail("smtp.gmail.com", 587, "restaraunt.delivery@gmail.com", "pkmcojlrxogidpjw", mail);
        }

        public string ReadResource()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("TemplateEmail.txt"));

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
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

        private void CodeTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 6)
            {
                if ((sender as TextBox).Text == GeneratedCode)
                {
                    SpCode.Visibility = Visibility.Collapsed;
                    var selectedEmail = App.DB.Employee.FirstOrDefault(x => x.Email == Email);
                    if (selectedEmail != null)
                    {
                        selectedEmail.Password = GenerateLoginPassword();
                        App.DB.SaveChanges();
                        var result = MessageBox.Show(selectedEmail.Password,
                                                    "Новый пароль",
                                                    MessageBoxButton.OK,
                                                    MessageBoxImage.Information);
                        if (result == MessageBoxResult.OK || result == MessageBoxResult.Cancel)
                        {
                            NavigationService.GoBack();
                        };
                    }
                }
            }
        }
    }
}
