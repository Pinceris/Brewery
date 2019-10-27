using System.ComponentModel;

namespace BeerManagment.Models.Beer
{
    public class BeerView
    {
        public string Id { get; set; }
        [DisplayName("Type")]
        public string TypeName { get; set; }
        public string Title { get; set; }
        public float Volume { get; set; }
        [DisplayName("Non Alcoholic")]
        public bool NonAlcohol { get; set; }
    }
}