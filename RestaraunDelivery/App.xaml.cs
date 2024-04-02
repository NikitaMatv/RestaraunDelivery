using RestaraunDelivery.Components;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RestaraunDelivery
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static RestarauntDeliveryEntities DB = new RestarauntDeliveryEntities();
        public static Customer LoggedCustomer;
        public static bool IsAutorizate = false;
    }
}


