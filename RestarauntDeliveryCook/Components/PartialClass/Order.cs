using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntDeliveryCook.Components
{
   public partial class Order
    {
        TimeSpan Timer
        {
            get
            {
                return (TimeSpan)(DateTimes - DateTime.Now);
            }
        }
    }
}
