using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerManagment.Models.BeerConsumption
{
    public class BeerNameTypeConsume
    {
        public List<BeerNameConsume> ByName { get; set; }
        public List<BeerTypeConsume> ByType { get; set; }
    }
}