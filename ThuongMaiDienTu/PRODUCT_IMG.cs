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
    
    public partial class PRODUCT_IMG
    {
        public int IdImg { get; set; }
        public string Filename { get; set; }
        public string ImgAlt { get; set; }
        public int IdProduct { get; set; }
    
        public virtual PRODUCT PRODUCT { get; set; }
        public virtual PRODUCT PRODUCT1 { get; set; }
    }
}
