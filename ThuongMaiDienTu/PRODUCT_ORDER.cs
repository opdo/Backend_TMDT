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
    
    public partial class PRODUCT_ORDER
    {
        public int IdProduct { get; set; }
        public int IdOrder { get; set; }
        public Nullable<byte> Count { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> Discount { get; set; }
        public string IMEI { get; set; }
    
        public virtual ORDER ORDER { get; set; }
        public virtual ORDER ORDER1 { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
        public virtual PRODUCT PRODUCT1 { get; set; }
        public virtual PRODUCT PRODUCT2 { get; set; }
        public virtual PRODUCT PRODUCT3 { get; set; }
    }
}
