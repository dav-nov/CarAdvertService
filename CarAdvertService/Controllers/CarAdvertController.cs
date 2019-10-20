using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using CarAdvertService.Controllers.HelperClasses;

namespace CarAdvertService.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class CarAdvertController : ApiController
    {
        // dummy data for testing purposes
        private List<CarAdvertViewModel> _dummyAdvertList;
        private PropertyHelper _propertyHelper;
        public List<CarAdvertViewModel> DummyAdvertList
        {
            get { return _dummyAdvertList; }
            set { _dummyAdvertList = value; }
        }

        #region ctor
        public CarAdvertController()
        {
            _dummyAdvertList = StaticContext.Instance.DummyAdvertList;
            _propertyHelper = new PropertyHelper();
        }
        #endregion

        // GET api/caradvert
        public IEnumerable<CarAdvertViewModel> GetAll(string sortby = null)
        {
            // This will be used if DB connection failed
            List<CarAdvertViewModel> advertLst = DummyAdvertList;

            return advertLst.OrderBy(x => _propertyHelper.GetProperty(x, sortby)).ToList(); ;
        }

        // GET api/caradvert/5
        public CarAdvertViewModel GetAdvertById(int id)
        {
            // This will be used if DB connection failed
            List<CarAdvertViewModel> advertLst = DummyAdvertList;

            return advertLst.FirstOrDefault(x => x.Id == id);
        }

        // POST api/caradvert
        public IHttpActionResult PostAdvert([FromBody]CarAdvertViewModel advert)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            // This will be used if DB connection failed
            List<CarAdvertViewModel> advertLst = DummyAdvertList;

            DummyAdvertList.Add(new CarAdvertViewModel()
            {
                Id = advertLst.Count() + 1,
                Title = advert.Title,
                Fuel = advert.Fuel,
                Price = advert.Price,
                New = advert.New,
                Mileage = advert.New ? null : advert.Mileage,
                FirstRegistration = advert.New ? null : advert.FirstRegistration
        });

            return Ok();
        }

        // PUT api/caradvert/5
        public void PutAdvert(int id, [FromBody]CarAdvertViewModel advert)
        {
            // This will be used if DB connection failed
            List<CarAdvertViewModel> advertLst = DummyAdvertList;

            CarAdvertViewModel existingAdvert = advertLst.Where(x => x.Id == advert.Id).FirstOrDefault();

            if (existingAdvert != null)
            {
                existingAdvert.Title = advert.Title;
                existingAdvert.Fuel = advert.Fuel;
                existingAdvert.Price = advert.Price;
                existingAdvert.New = advert.New;
                existingAdvert.Mileage = advert.New ? null : advert.Mileage;
                existingAdvert.FirstRegistration = advert.New ? null : advert.FirstRegistration;
            }
            else
            {
                // NotFound
            }
        }

        public IHttpActionResult Put(CarAdvertViewModel advert)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");

            List<CarAdvertViewModel> advertLst = DummyAdvertList;

            CarAdvertViewModel existingAdvert = advertLst.Where(x => x.Id == advert.Id).FirstOrDefault();

            if (existingAdvert != null)
            {
                existingAdvert.Title = advert.Title;
                existingAdvert.Fuel = advert.Fuel;
                existingAdvert.Price = advert.Price;
                existingAdvert.New = advert.New;
                existingAdvert.Mileage = advert.New ? null : advert.Mileage;
                existingAdvert.FirstRegistration = advert.New ? null : advert.FirstRegistration;
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }


        // DELETE api/caradvert/5
        public IHttpActionResult DeleteAdvert(int id)
        {
            // This will be used if DB connection failed
            List<CarAdvertViewModel> advertLst = DummyAdvertList;

            CarAdvertViewModel advert = advertLst.Where(a => a.Id == id).FirstOrDefault();

            if (id <= 0 || advert == null)
                return BadRequest("Not a valid advert id");

            if (advert != null)
                advertLst.Remove(advert);

            return Ok();
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
