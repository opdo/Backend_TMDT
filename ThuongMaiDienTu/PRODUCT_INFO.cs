//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThuongMaiDienTu
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCT_INFO
    {
        public int IdProduct { get; set; }
        public int IdInfo { get; set; }
        public string Info { get; set; }
    
        public virtual INFO INFO1 { get; set; }
        public virtual INFO INFO2 { get; set; }
        public virtual INFO INFO3 { get; set; }
        public virtual INFO INFO4 { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
        public virtual PRODUCT PRODUCT1 { get; set; }
        public virtual PRODUCT PRODUCT2 { get; set; }
        public virtual PRODUCT PRODUCT3 { get; set; }
    }
}
