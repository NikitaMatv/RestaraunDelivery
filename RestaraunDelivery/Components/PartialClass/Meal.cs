using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaraunDelivery.Components
{
    public partial class Meal
    {
        public Visibility VisabilityBt
        {
            get
            {
                Order_Meal meal = App.DB.Order_Meal.FirstOrDefault(x => x.MealID == ID && x.OrderID == null && x.CustomerID == App.LoggedCustomer.ID);
                if (meal != null)
                {
                    return Visibility.Hidden;
                }
                return Visibility.Visible;
            }

        }
    }
}
