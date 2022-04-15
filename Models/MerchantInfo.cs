using System;
using System.Collections.Generic;

namespace Santander.Models
{
    public partial class MerchantInfo
    {
        public int MerchantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
