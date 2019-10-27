using System;
using System.ComponentModel;

namespace BeerManagment.Models.BeerConsumption
{
    public class BeerConsumptionView
    {
        [DisplayName("Beer Name")]
        public string BeerName { get; set; }
        public Int32 Quantity { get; set; }
        [DisplayName("Created At")]
        public DateTime CreatedAt { get; set; }
    }
}