//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZHK
{
    using System;
    using System.Collections.Generic;
    
    public partial class ResidentialComplex
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ResidentialComplex()
        {
            this.Houses = new HashSet<House>();
        }
    
        public byte ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Status { get; set; }
        public Nullable<int> BuildingCost { get; set; }
        public Nullable<int> ComplexValueAdded { get; set; }
        public Nullable<byte> IsDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<House> Houses { get; set; }
    }
}
