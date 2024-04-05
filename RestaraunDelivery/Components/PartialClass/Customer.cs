using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaraunDelivery.Components
{
    public partial class Customer
    {
        public string StrFullName
        {
            get
            {
                if (Patronymic == null)
                {
                    return $"{SurName} {FirstName.ToCharArray()[0]}.";
                }
                else
                {
                    return $"{SurName} {FirstName.ToCharArray()[0]}. {Patronymic.ToCharArray()[0]}.";
                }

            }
        }
    }
}
