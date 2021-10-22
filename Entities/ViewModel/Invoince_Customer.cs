using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModel
{
   public  class Invoince_Customer
    {
        public string CustomerIdentity{ get; set; }
        public string CustomerName { get; set; }
        public string customerLastName { get; set; }
        public string InvoinceType { get; set; }
        public int InvoinceNumber { get; set; }
        public decimal InvoinceAmount { get; set; }
        public int InvoinceSituation { get; set; }
        public DateTime InvoinceTime { get; set; }
        public DateTime InvoinceDeliveryTime { get; set; }
    }
}
