

namespace BeerManagment.Models.Beer
{
    public class Beer
    {
        public string BeerId { get; set; }
        public string TypeId { get; set; }
        public string Title { get; set; }
        public float Volume { get; set; }
        public bool NonAlcohol { get; set; }
    }
}