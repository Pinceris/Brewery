using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerManagment.Models
{
    public class BeerView
    {
        public string Id { get; set; }
        public string TypeName { get; set; }
        public string Title { get; set; }
        public float Volume { get; set; }
        public bool NonAlcohol { get; set; }
    }
}