using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkapurBAL
{
    public class EmployeeProperties
    {
        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Mobile1 { get; set; }

        public string Mobile2 { get; set; }

        public bool Active { get; set; }

        public string RestCode { get; set; }

        public string Remarks { get; set; }

        public int UserTypeId { get; set; }

        public string PhotoUrl { get; set; }

        public string EmailId { get; set; }

        public string UserCode { get; set; }

        public string EmpCode { get; set; }

        public string Password { get; set; }

        public int Flag { get; set; }
        public byte[] Image { get; set; } 
         

        public string CustPhoneNumber { get; set; }
        public string CustomerFName { get; set; }
        public string CustomerLName { get; set; }
        public string Billing_Address { get; set; }
        public int CustomerTypeId { get; set; }
        public string Delivery_Addresss { get; set; }
    }
}
