using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarAdvertService;
using CarAdvertService.Controllers;

namespace CarAdvertService.Tests.Controllers
{
    [TestClass]
    public class CarAdvertControllerTest
    {
        public List<CarAdvertViewModel> TestAdvertList = new List<CarAdvertViewModel>
        {
            new CarAdvertViewModel(1) {Title = "BMW X7", Fuel = 1, Price = 90000, New = true, Mileage = null, FirstRegistration = null},
            new CarAdvertViewModel(2) {Title = "Porsche 911", Fuel = 0, Price = 120000, New = true, Mileage = 70000, FirstRegistration = DateTime.Parse("12.12.2012")},
            new CarAdvertViewModel(3) {Title = "Fiat Panda", Fuel = 1, Price = 2000, New = true, Mileage = 65000, FirstRegistration = DateTime.Parse("01.05.2008")},
            new CarAdvertViewModel(4) {Title = "VW Sharan", Fuel = 0, Price = 7000, New = true, Mileage = 105000, FirstRegistration = DateTime.Parse("10.10.2000")},
            new CarAdvertViewModel(5) {Title = "Audi A4 Avant", Fuel = 1, Price = 75000, New = true, Mileage = null, FirstRegistration = null},
            new CarAdvertViewModel(6) {Title = "Mercedes CLK", Fuel = 0, Price = 12000, New = true, Mileage = 150000, FirstRegistration = DateTime.Parse("06.06.2006")},
        };


        [TestMethod]
        public void Get()
        {
            // Arrange
            CarAdvertController controller = new CarAdvertController();
            controller.DummyAdvertList = TestAdvertList;
            // Act
            IEnumerable<CarAdvertViewModel> result = controller.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(6, result.Count());
            Assert.AreEqual(TestAdvertList.FirstOrDefault(), result.ElementAt(0));
            Assert.AreEqual(TestAdvertList.LastOrDefault(), result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            CarAdvertController controller = new CarAdvertController();
            controller.DummyAdvertList = TestAdvertList;
            // Act
            CarAdvertViewModel result = controller.GetAdvertById(5);

            // Assert
            Assert.AreEqual(TestAdvertList.ElementAtOrDefault(5), result.Id);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            CarAdvertController controller = new CarAdvertController();

            // Act
            controller.PostAdvert(new CarAdvertViewModel());

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            CarAdvertController controller = new CarAdvertController();

            // Act
            controller.PutAdvert(5, new CarAdvertViewModel(5));

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            CarAdvertController controller = new CarAdvertController();

            // Act
            controller.DeleteAdvert(5);

            // Assert
        }
    }
}
