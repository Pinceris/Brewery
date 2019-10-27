using System.ComponentModel;

namespace BeerManagment.Models.BeerConsumption
{
    public class BeerNameConsume
    {
        [DisplayName("Name")]
        public string BeerName {get; set;}
        public int Quantity { get; set; }
        public int Occurrences { get; set; }
        public decimal Avarage { get; set; }
    }
}