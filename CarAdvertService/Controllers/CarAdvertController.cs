using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarAdvertService.Controllers
{
    public class CarAdvertController : ApiController
    {
        // GET api/values
        public IEnumerable<CarAdvert> GetAll(string sortby = null)
        {
            List<CarAdvert> advertLst = new List<CarAdvert>();
            for (int i = 1; i < 10; i++)
                advertLst.Add(new CarAdvert(i));
            
            return advertLst;
        }

        // GET api/values/5
        public CarAdvert GetAdvertById(int id)
        {
            return new CarAdvert();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
