//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPFApp1.Model.AppDBcontext
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersonsReesters
    {
        public Nullable<int> reester_personID { get; set; }
        public Nullable<int> personID { get; set; }
        public int ID { get; set; }
    
        public virtual Main_Reestr Main_Reestr { get; set; }
        public virtual Respons_persons Respons_persons { get; set; }
    }
}