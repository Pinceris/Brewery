using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerManagment.Models.Beer
{
    public class BeerCreate
    {
        public String Title { get; set; }
        public string TypeName { get; set; }
        public float Volume { get; set; }
        public bool NonAlcohol { get; set; }
    }
}