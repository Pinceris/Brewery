using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BeerManagment.Models
{
    public class BeerCreateView
    {
        public string Id { get; set; }
        public string TypeId { get; set; }
        public string Title { get; set; }
        public float Volume { get; set; }
        public bool NonAlcohol { get; set; }
        public List<BeerType> TypeList { get; set; }
    }
}