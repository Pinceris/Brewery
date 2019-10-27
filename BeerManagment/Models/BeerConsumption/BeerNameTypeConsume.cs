using System.Collections.Generic;

namespace BeerManagment.Models.BeerConsumption
{
    public class BeerNameTypeConsume
    {
        public List<BeerNameConsume> ByName { get; set; }
        public List<BeerTypeConsume> ByType { get; set; }
    }
}