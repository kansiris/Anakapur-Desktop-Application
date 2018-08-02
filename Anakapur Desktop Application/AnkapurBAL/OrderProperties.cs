using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkapurBAL
{
   public class OrderProperties
    {
        public string OrderId { get; set; }
        public int StatusId { get; set; }
        public string EmpCode { get; set; }
        public string CustPhone { get; set; }
        public int TypeOforder { get; set; }
        public string Tip { get; set; }
        public string Discount { get; set; }
        public decimal AmountPaid { get; set; }
        public string Remarks { get; set; }
    }
}
