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
    
    public partial class U_D
    {
        public int id_u_d { get; set; }
        public int id_u { get; set; }
        public int id_d { get; set; }
    
        public virtual Discs Discs { get; set; }
        public virtual Users Users { get; set; }
    }
}
