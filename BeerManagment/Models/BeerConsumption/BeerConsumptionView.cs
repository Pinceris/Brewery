using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

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