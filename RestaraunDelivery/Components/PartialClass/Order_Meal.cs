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
        public Visibility VisabilityBt
        {
            get
            {
                if (Count == 20)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }               
            }

        }
    }
}
     

