using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestatauntDeliveryShev.Components
{
    public partial class Employee
    {
        public string StrFullName
        {
            get
            {
                if (Patronymic == null)
                {
                    return $"{Surname} {Name.ToCharArray()[0]}.";
                }
                else
                {
                    return $"{Surname} {Name.ToCharArray()[0]}. {Patronymic.ToCharArray()[0]}.";
                }

            }
        }

    }
}
