//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestarauntDeliveryAdministrator.Components
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ingridient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ingridient()
        {
            this.Meal_Ingridient = new HashSet<Meal_Ingridient>();
            this.Supplier_ingridient = new HashSet<Supplier_ingridient>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<double> Price { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Meal_Ingridient> Meal_Ingridient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supplier_ingridient> Supplier_ingridient { get; set; }
    }
}
