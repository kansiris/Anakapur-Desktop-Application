using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkapurBAL
{
    public class BreakFastProperties
    {
        public int CategoryId { get; set; }
        public string CategoryType { get; set; }

        //for OrderDetails

        public string OrderId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int flag { get; set; }
        public int StatusId { get; set; }
        public string EmpCode { get; set; }
        public string RestCode { get; set; }
        public string deliveryboy { get; set; }
        public override string ToString()
        {
            return this.ProductName + "    " + this.Quantity;
        }
        //public override string ToString()
        //{
        //    return  this.ProductName +"    "+ this.Quantity;
        //}
        public decimal totalamount { get; set; }
    }
}
