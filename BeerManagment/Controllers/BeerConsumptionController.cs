using BeerManagment.Models.BeerConsumption;
using BeerManagment.Models.BeerType;
using BeerManagment.Models.Beer;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeerManagment.Controllers
{
    public class BeerConsumptionController : Controller
    {
        //GET: Index
        public async Task<ActionResult> Index()
        {
            List<BeerConsume> beerCons = await ApiClient.GetAllAsync<BeerConsume>("ConsumedBeers/");
            List<Beer> beers = await ApiClient.GetAllAsync<Beer>("Beers/");

            List<BeerConsumptionView> finalResult = new List<BeerConsumptionView>();

            foreach(BeerConsume bc in beerCons)
            {
                BeerConsumptionView result = new BeerConsumptionView();
                foreach(Beer beer in beers)
                {
                    if (bc.BeerId == beer.BeerId) result.BeerName = beer.Title;
                }
                result.Quantity = bc.Quantity;
                result.CreatedAt = bc.CreatedAt;
                finalResult.Add(result);
            }

            return View(finalResult);
        }
        //GET: Stats
        public async Task<ActionResult> Full()
        {
            BeerNameTypeConsume resultFinal = new BeerNameTypeConsume();

            List<BeerConsume> beerC = await ApiClient.GetAllAsync<BeerConsume>("ConsumedBeers/");
            List<Beer> beers = await ApiClient.GetAllAsync<Beer>("Beers/");

            List<BeerNameConsume> beerFinal = new List<BeerNameConsume>();

            foreach (Beer beer in beers)
            {
                bool empty = true;
                BeerNameConsume result = new BeerNameConsume();

                foreach (BeerConsume bc in beerC)
                {
                    if (beer.BeerId == bc.BeerId)
                    {
                        empty = false;
                        result.BeerName = beer.Title;
                        result.Quantity += bc.Quantity;
                        result.Occurrences++;
                    }
                }
                if (!empty)
                {
                    result.Avarage = result.Quantity / result.Occurrences;
                    beerFinal.Add(result);
                }
            }

            List<BeerTypeConsume> typeFinal = new List<BeerTypeConsume>();
            List<BeerType> beerTypes = await ApiClient.GetAllAsync<BeerType>("BeerTypes/");

            foreach (BeerType type in beerTypes)
            {
                bool empty = true;
                BeerTypeConsume result = new BeerTypeConsume();

                foreach(Beer beer in beers)
                {
                    foreach (BeerConsume bc in beerC)
                    {
                        if(beer.BeerId==bc.BeerId)
                        {
                            if(type.Id == beer.TypeId)
                            {
                                empty = false;
                                result.BeerType = type.Name;
                                result.Occurrences++;
                                result.Quantity += bc.Quantity;
                            }                            
                        }
                    }
                }
                if (!empty)
                {
                    result.Avarage = result.Quantity / result.Occurrences;
                    typeFinal.Add(result);
                }
            }
            resultFinal.ByName = beerFinal;
            resultFinal.ByType = typeFinal;

            return View(resultFinal);
        }
    }
}
