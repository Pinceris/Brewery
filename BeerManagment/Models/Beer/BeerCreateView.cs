using BeerManagment.Models.BeerType;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BeerManagment.Models.Beer
{
    public class BeerCreateView
    {
        public string Id { get; set; }
        [DisplayName("Type name")]
        public string TypeId { get; set; }
        public string Title { get; set; }
        public float Volume { get; set; }
        [DisplayName("Non Alcoholic")]
        public bool NonAlcohol { get; set; }
        public List<BeerType.BeerType> TypeList { get; set; }
    }
}