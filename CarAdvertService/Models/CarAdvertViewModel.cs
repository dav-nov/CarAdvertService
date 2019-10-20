using CarAdvertService.Controllers.HelperClasses;
using CarAdvertService.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CarAdvertService.Controllers
{
    [DataContract]
    public class CarAdvertViewModel
    {
        public CarAdvertViewModel() { }

        public CarAdvertViewModel(int? id = null)
        {
            Id = id ?? 1;
            Title = "Car Advert " + Id.ToString();
            Fuel = id % 2 == 0 ? FuelType.Gasoline : FuelType.Diesel;
            Price = Id * 1000;
            New = id % 2 == 0;
            Mileage = New ? (int?)null : 100000 - (Id * 900);
            FirstRegistration = New ? (DateTime?)null : DateTime.Today.AddYears(-Id);
        }
        [Required]
        [DataMember]
        public int Id { get; set; }
        [Required]
        [DataMember]
        public string Title { get; set; }
        [Required]
        [DataMember]
        public FuelType Fuel { get; set; }
        public int Fueltype => (int)Fuel;
        [Required]
        [DataMember]
        public int Price { get; set; }
        [Required]
        [DataMember]
        public bool New { get; set; }
        [RequiredDependentOnNewAttribute]
        [DataMember]
        public int? Mileage { get; set; }
        [RequiredDependentOnNewAttribute]
        [DataMember]
        [Display(Name = "First registration")]
        [JsonProperty(PropertyName = "First registration", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FirstRegistration { get; set; }
    }
}