using System.ComponentModel;

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