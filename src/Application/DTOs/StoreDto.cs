using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class StoreDto
    {
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool VATIncluded { get; set; }
        public decimal VATRate { get; set; }
        public decimal ShippingCost { get; set; }
    }
}
