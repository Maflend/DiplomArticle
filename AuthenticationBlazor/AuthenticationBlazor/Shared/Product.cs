using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationBlazor.Shared
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } = 0.00m;
        public decimal PurchasePrice { get; set; } = 0.00m;


    }
}
