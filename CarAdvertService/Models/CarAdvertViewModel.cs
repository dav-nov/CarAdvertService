using System;
using System.Runtime.Serialization;

namespace CarAdvertService.Controllers
{
    [DataContract]
    public class CarAdvertViewModel
    {
        public CarAdvertViewModel(int? id = null)
        {
            Id = id ?? 1;
            Title = "Car " + Id.ToString();
            Fuel = 1;
            Price = Id * 1000;
            New = false;
            Mileage = 100000 - (Id * 1000);
            FirstRegistration = DateTime.Today.AddYears(-Id);
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public int Fuel { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public bool New { get; set; }
        [DataMember]
        public int? Mileage { get; set; }
        [DataMember]
        public DateTime? FirstRegistration { get; set; }
    }
}