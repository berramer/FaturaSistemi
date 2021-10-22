using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
   public  class Invoice
    {
        public int InvoiceNumber { get; set; }
        [Key]
        public int InvoiceId { get; set; }
        public string CustomerIdentity { get; set; }
        public string InvoiceType { get; set; }
        public decimal InvoiceAmount { get; set; }
        public int InvoiceSituation { get; set; }
        public DateTime InvoiceTime { get; set; }
        public DateTime InvoiceDeliveryTime { get; set; }

    }
}
