using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaraunDelivery.Components
{
   public partial class Order
    {
        public string StrAddress
        {
            get
            {
                if (Address != string.Empty)
                {
                    return Address;
                }
                else
                {
                    return App.DB.Restaurant.FirstOrDefault(x=>x.ID == RestaurantID).Addres.ToString();
                }
               
            }
        }
    }
}
