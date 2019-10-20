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
            Fuel = id % 2 == 0 ? 1 : 2;
            Price = Id * 1000;
            New = id % 2 == 0;
            Mileage = New ? 0 : 100000 - (Id * 900);
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
        [Range(0, 2)]
        public int Fuel { get; set; }
        [Required]
        [DataMember]
        public int Price { get; set; }
        [Required]
        [DataMember]
        public bool New { get; set; }
        [DataMember]
        public int? Mileage { get; set; }
        [DataMember]
        [Display(Name = "First registration")]
        [JsonProperty(PropertyName = "First registration", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FirstRegistration { get; set; }
    }
}