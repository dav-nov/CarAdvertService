using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CarAdvertService.Controllers
{
    public class HomeController : Controller
    {
        // GET: advert
        public ActionResult Index()
        {
            IEnumerable<CarAdvertViewModel> adverts = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63915/api/");
                //HTTP GET
                var responseTask = client.GetAsync("caradvert");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CarAdvertViewModel>>();
                    readTask.Wait();

                    adverts = readTask.Result;
                }
                else //web api sent error response 
                {
                    adverts = Enumerable.Empty<CarAdvertViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(adverts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(CarAdvertViewModel advert)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63915/api/caradvert/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<CarAdvertViewModel>("caradvert", advert);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(advert);
        }

        public ActionResult Edit(int id)
        {
            CarAdvertViewModel advert = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63915/api/");
                //HTTP GET
                var responseTask = client.GetAsync("caradvert?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CarAdvertViewModel>();
                    readTask.Wait();

                    advert = readTask.Result;
                }
            }

            return View(advert);
        }

        [HttpPost]
        public ActionResult Edit(CarAdvertViewModel advert)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63915/api/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<CarAdvertViewModel>("caradvert", advert);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(advert);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63915/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("caradvert/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}
