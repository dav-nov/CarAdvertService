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
        // dummy data for testing purposes
        private List<CarAdvertViewModel> _dummyAdvertList;
        public List<CarAdvertViewModel> DummyAdvertList
        {
            get { return _dummyAdvertList; }
            set { _dummyAdvertList = value; }
        }

        #region ctor
        public CarAdvertController()
        {
            _dummyAdvertList = createDummyData();
        }
        #endregion

        // GET api/caradvert
        public IEnumerable<CarAdvertViewModel> GetAll(string sortby = null)
        {
            // This will be used if DB connection failed
            List<CarAdvertViewModel> advertLst = DummyAdvertList;


            return advertLst;
        }

        // GET api/caradvert/5
        public CarAdvertViewModel GetAdvertById(int id)
        {
            return new CarAdvertViewModel();
        }

        // POST api/caradvert
        public void PostAdvert([FromBody]CarAdvertViewModel advert)
        {
        }

        // PUT api/caradvert/5
        public void PutAdvert(int id, [FromBody]CarAdvertViewModel advert)
        {
        }

        // DELETE api/caradvert/5
        public void DeleteAdvert(int id)
        {
        }

        #region private methods
        /// <summary>
        /// Creates dummy data for testing purposes
        /// </summary>
        /// <returns>List of <list type="CarAdvertViewModel"></list></returns>
        private List<CarAdvertViewModel> createDummyData()
        {
            List<CarAdvertViewModel> advertLst = new List<CarAdvertViewModel>();
            for (int i = 1; i < 10; i++)
                advertLst.Add(new CarAdvertViewModel(i));

            return advertLst;
        }
        #endregion
    }
}
