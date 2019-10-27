using BeerManagment.Models.BeerType;
using BeerManagment.Models.Beer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using BeerManagment.Models.BeerConsumption;

namespace BeerManagment.Controllers
{
    public class BeerController : Controller
    {
        // GET: Beer
        public async Task<ActionResult> Index()
        {
            List<Beer> beers = await ApiClient.GetAllAsync<Beer>("Beers/");

            List<BeerType> beerTypes = await ApiClient.GetAllAsync<BeerType>("BeerTypes/");

            List<BeerView> finalResult = new List<BeerView>();

            foreach (Beer beer in beers)
            {
                BeerView result = new BeerView();
                foreach (BeerType beerType in beerTypes)
                {
                    if (beer.TypeId == beerType.Id) result.TypeName = beerType.Name;
                }
                result.Id = beer.BeerId;
                result.Title = beer.Title;
                result.Volume = beer.Volume;
                result.NonAlcohol = beer.NonAlcohol;
                finalResult.Add(result);
            }

            return View(finalResult);

        }

        // GET: Beer/Details/5
        public async Task<ActionResult> Details(String id)
        {
            Beer beer = await ApiClient.GetSingleAsync<Beer>("Beers/", id);
            List<BeerType> beerTypes = await ApiClient.GetAllAsync<BeerType>("BeerTypes/");
            BeerView result = new BeerView();

            foreach (BeerType beerType in beerTypes)
            {
                if (beer.TypeId == beerType.Id) result.TypeName = beerType.Name;
            }
            result.Id = beer.BeerId;
            result.Title = beer.Title;
            result.Volume = beer.Volume;
            result.NonAlcohol = beer.NonAlcohol;

            return View(result);
        }

        // GET: Beer/Create
        public async Task<ActionResult> Create()
        {
            BeerCreateView beer = new BeerCreateView();

            beer.TypeList = await ApiClient.GetAllAsync<BeerType>("BeerTypes/");

            return View(beer);
        }

        // POST: Beer/Create
        [HttpPost]
        public async Task<ActionResult> Create(BeerCreateView bc)
        {
            try
            {
                await ApiClient.PostAsync<BeerCreateView>(bc, "Beers/");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Beer/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            BeerCreateView magicBeer = await ApiClient.GetSingleAsync<BeerCreateView>("Beers/",id);
            magicBeer.TypeList = await ApiClient.GetAllAsync<BeerType>("BeerTypes/");

            return View(magicBeer);
        }

        // POST: Beer/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(string id, BeerCreateView b)
        {
            try
            {
                await ApiClient.PutObjectAsync<BeerCreateView>(b, "beers/", id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Beer/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            await ApiClient.DeleteByIdAsync("Beers/", id);

            return RedirectToAction("Index");
        }
        //GET: /ConsumedBeers
        public ActionResult Drink(string id)
        {
            BeerConsumptionCreateView bcc = new BeerConsumptionCreateView();
            bcc.BeerId = id;

            return View(bcc);
        }
        //POST: /ConsumedBeers
        [HttpPost]
        public async Task<ActionResult> Drink(BeerConsumptionCreateView bcc)
        {
            try
            {
                await ApiClient.PostAsync<BeerConsumptionCreateView>(bcc, "ConsumedBeers/");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

