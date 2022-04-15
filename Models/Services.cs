using System;
using System.Collections.Generic;

namespace Santander.Models
{
    public partial class Services
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int Available { get; set; }
    }
}
