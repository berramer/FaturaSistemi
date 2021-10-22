using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
   public  class SystemUser
    {   
        [Key]
        public int adminId { get; set; }
        public string UserName { get; set; }
        public string UserLastname { get; set; }
        public string SystemUserName { get; set; }

        public string email { get; set; }
        public string Password { get; set; }
    }
}
