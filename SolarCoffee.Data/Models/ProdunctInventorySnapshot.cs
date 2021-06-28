using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCoffee.Data.Models
{
    public class ProdunctInventorySnapshot
    {
        public int Id { get; set; }
        public DateTime SnapshotTIme { get; set; }
        public int QuantityOnHand { get; set; }
        public Product Product { get; set; }
    }
}
