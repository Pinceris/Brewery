using System;

namespace BeerManagment.Models.BeerConsumption
{
    public class BeerConsumptionCreateView
    {
        public string BeerId { get; set; }
        public Int32 Quantity { get; set; }
    }
}