//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentNoteMVC.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_grades
    {
        public int grd_id { get; set; }
        public Nullable<byte> grd_cls_id { get; set; }
        public Nullable<byte> grd_std_id { get; set; }
        public Nullable<byte> grd_exam1 { get; set; }
        public Nullable<byte> grd_exam2 { get; set; }
        public Nullable<byte> grd_exam3 { get; set; }
        public Nullable<byte> grd_project { get; set; }
        public Nullable<decimal> grd_average { get; set; }
        public Nullable<bool> grd_status { get; set; }
    
        public virtual tbl_classes tbl_classes { get; set; }
        public virtual tbl_students tbl_students { get; set; }
    }
}
