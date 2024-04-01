using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaraunDelivery.Components
{
    public partial class Order_Meal
    {
      public  Visibility VisabilityBt
        {
            get
            {
                int MId = (int)MealID;
                Order_Meal meal = App.DB.Order_Meal.FirstOrDefault(x => x.ID == MId);
                if(CustomerID == App.LoggedCustomer.ID && OrderID == null != true)
                {
                    if (meal != null)
                    {
                        return Visibility.Hidden;
                    }
                    else
                    {
                        return Visibility.Visible;
                    }
                    
                }
                return Visibility.Visible;
            }
           
        }
     
    }
}
