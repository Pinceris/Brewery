using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerManagment.Models.BeerConsumption
{
    public class BeerConsume
    {
        public string Id { get; set; }
        public string BeerId { get; set; }
        public Int32 Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}