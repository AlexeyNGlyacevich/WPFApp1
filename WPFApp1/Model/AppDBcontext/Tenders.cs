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
    
    public partial class Tenders
    {
        public int ID { get; set; }
        public Nullable<int> IDKey { get; set; }
        public Nullable<int> Num_purchase { get; set; }
        public Nullable<System.DateTime> Date_purchase { get; set; }
        public Nullable<System.DateTime> final__proposal_date { get; set; }
        public Nullable<System.DateTime> trading_date { get; set; }
        public string Object_name { get; set; }
        public string subject_of_a_contract { get; set; }
        public Nullable<double> starting_price { get; set; }
        public Nullable<double> price_date_submission { get; set; }
        public Nullable<double> price_inclusive_reduction { get; set; }
        public string Result { get; set; }
        public Nullable<System.DateTime> Acceptance_date { get; set; }
        public Nullable<System.DateTime> Term_of_the_contract { get; set; }
        public string Repository { get; set; }
    
        public virtual Main_Reestr Main_Reestr { get; set; }
    }
}
