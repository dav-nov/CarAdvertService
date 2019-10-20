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
                    //log response status here..

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
    }
}
