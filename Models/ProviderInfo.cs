//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Service.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProviderInfo
    {
        public int id { get; set; }
        public Nullable<System.Guid> ProviderId { get; set; }
        public string Category { get; set; }
        public Nullable<int> Zipcode { get; set; }
        public string city { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public Nullable<int> MobileNumber { get; set; }
        public Nullable<int> AlternateNumber { get; set; }
        public Nullable<int> AdharNumber { get; set; }
        public string AboutMe { get; set; }
        public Nullable<System.DateTime> DayStart { get; set; }
        public Nullable<System.DateTime> DayEnd { get; set; }
        public string Workindays { get; set; }
        public byte[] Photid { get; set; }
        public string UserName { get; set; }
        public string Photo { get; set; }
        public string AlternateText { get; set; }
        public bool IsProfileCompleted { get; set; }
    }
}
