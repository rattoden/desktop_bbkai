//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace desktop_bbkai
{
    using System;
    using System.Collections.Generic;
    
    public partial class Doki
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Doki()
        {
            this.Otcheti = new HashSet<Otcheti>();
        }
    
        public int id_d { get; set; }
        public int id_u { get; set; }
        public int id_v { get; set; }
        public string name_d { get; set; }
        public string ssilka_d { get; set; }
        public int flag_d { get; set; }
        public int id_di { get; set; }
    
        public virtual Discs Discs { get; set; }
        public virtual Users Users { get; set; }
        public virtual Vidi Vidi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Otcheti> Otcheti { get; set; }
    }
}