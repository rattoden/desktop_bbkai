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
    
    public partial class Otcheti
    {
        public int id_o { get; set; }
        public int id_d { get; set; }
        public int id_u { get; set; }
        public string ssilka { get; set; }
        public System.DateTime date_o { get; set; }
    
        public virtual Doki Doki { get; set; }
        public virtual Users Users { get; set; }
    }
}
