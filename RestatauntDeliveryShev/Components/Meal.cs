//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestatauntDeliveryShev.Components
{
    using System;
    using System.Collections.Generic;
    
    public partial class Meal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Meal()
        {
            this.Meal_Ingridient = new HashSet<Meal_Ingridient>();
            this.Order_Meal = new HashSet<Order_Meal>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<double> Price { get; set; }
        public byte[] Images { get; set; }
        public Nullable<int> CotegoriesID { get; set; }
        public string Description { get; set; }
    
        public virtual Cotegories Cotegories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Meal_Ingridient> Meal_Ingridient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Meal> Order_Meal { get; set; }
    }
}
