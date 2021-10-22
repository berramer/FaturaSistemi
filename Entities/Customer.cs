using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
  public   class Customer
    {   
        [Key]
        public int customerId { get; set; }
        public string customerName { get; set; }
        public string customerLastName { get; set; }
        public string customerIdentity { get; set; }
        public string customerAddress { get; set; }
        public string customerPhoneNumber { get; set; }
        public string memberships { get; set; }
        public string password { get; set; }

    }
}
