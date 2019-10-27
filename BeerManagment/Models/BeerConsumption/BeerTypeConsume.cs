using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BeerManagment.Models.BeerConsumption
{
    public class BeerTypeConsume
    {
        [DisplayName("Type")]
        public string BeerType { get; set; }
        public int Quantity { get; set; }
        public int Occurrences { get; set; }
        public decimal Avarage { get; set; }
    }
}