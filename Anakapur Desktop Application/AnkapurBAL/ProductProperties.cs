using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkapurBAL
{
    public class ProductProperties
    {
        public string ProductID { get; set; }
        public bool Available { get; set; }
        public string Remarks { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string Quantity { get; set; } 
        public string ImageUrl { get; set; }
        public int CategoryID { get; set; }
        public int DishTypeID { get; set; }
        public decimal Tax { get; set; } 
        public decimal Discounts { get; set; }
        public string tblname { get; set; }
        public string Restcode { get; set; }
        public string ItemCode { get; set; }
        public int Flag { get; set; }
        public byte[] Image { get; set; }
        public int SIH { get; set; }
        public string Kitchen_Description { get; set; }
    }
}
