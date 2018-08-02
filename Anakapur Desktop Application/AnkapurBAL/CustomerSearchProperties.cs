using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkapurBAL
{
   public class CustomerSearchProperties
    {
       // private String Something { get; set; } = string.Empty;

        public string CustomerFName { get; set; }

        public string CustomerLName { get; set; }

        public string CustPhoneNumber { get; set; }

        public string Billing_Address { get; set; }

        public string Delivery_Addresss { get; set; }

        public string Land_Mark { get; set; }

        public string Mobile1 { get; set; } = null;

        public string Mobile2 { get; set; } = null;

        public int CustomerTypeId { get; set; }

        public float? DeliveryLocationLatitude { get; set; } = null;
     //   float? nullFloat = null;

        public float? DeliveryLocationLongitude { get; set; } = null;


    }
}
