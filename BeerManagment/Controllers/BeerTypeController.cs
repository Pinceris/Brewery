using BeerManagment.Models.BeerType;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeerManagment.Controllers
{
    public class BeerTypeController : Controller
    {
        // GET: BeerType
        public async Task<ActionResult> Index()
        {
            List<BeerTypeCreate> beerType = await ApiClient.GetAllAsync<BeerTypeCreate>("BeerTypes/");

            return View(beerType);
        }

        // GET: BeerType/Details/5
        public ActionResult Details(string id)
        {

            return View();
        }

        // GET: BeerType/Create
        public ActionResult Create()
        {
            BeerTypeCreate beer = new BeerTypeCreate();

            return View(beer);
        }

        // POST: BeerType/Create
        [HttpPost]
        public async Task<ActionResult> Create(BeerTypeCreate bc)
        {
            try
            {
                await ApiClient.PostAsync<BeerTypeCreate>(bc, "BeerTypes/");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BeerType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BeerType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BeerType/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            await ApiClient.DeleteByIdAsync("BeerTypes/", id);

            return RedirectToAction("Index");
        }

        // POST: BeerType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
