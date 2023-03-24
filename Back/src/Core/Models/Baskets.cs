using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Baskets
    {
        public string Id { get; set; }
        public string BasketData { get; set; }
        public DateTime lastUpdated { get; set; }
    }
}