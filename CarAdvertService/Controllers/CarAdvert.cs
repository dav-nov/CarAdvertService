using System;

namespace CarAdvertService.Controllers
{
    public class CarAdvert
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Fuel { get; set; }
        public int Price { get; set; }
        public bool New { get; set; }
        public int? Mileage { get; set; }
        public DateTime? FirstRegistration { get; set; }
    }
}