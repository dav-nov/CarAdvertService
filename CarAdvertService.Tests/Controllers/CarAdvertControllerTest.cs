using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarAdvertService.Controllers;

namespace CarAdvertService.Tests.Controllers
{
    [TestClass]
    public class CarAdvertControllerTest
    {
        public IEnumerable<CarAdvertViewModel> TestAdvertList = new CarAdvertViewModel[]
        {
            new CarAdvertViewModel(1) {Title = "BMW X7", Fuel = Models.FuelType.Gasoline, Price = 90000, New = true, Mileage = null, FirstRegistration = null},
            new CarAdvertViewModel(2) {Title = "Porsche 911", Fuel = Models.FuelType.Diesel, Price = 120000, New = true, Mileage = 70000, FirstRegistration = DateTime.Parse("12.12.2012")},
            new CarAdvertViewModel(3) {Title = "Fiat Panda", Fuel = Models.FuelType.Gasoline, Price = 2000, New = true, Mileage = 65000, FirstRegistration = DateTime.Parse("01.05.2008")},
            new CarAdvertViewModel(4) {Title = "VW Sharan", Fuel = Models.FuelType.Diesel, Price = 7000, New = true, Mileage = 195000, FirstRegistration = DateTime.Parse("10.10.2000")},
            new CarAdvertViewModel(5) {Title = "Audi A4 Avant", Fuel = Models.FuelType.Gasoline, Price = 75000, New = true, Mileage = null, FirstRegistration = null},
            new CarAdvertViewModel(6) {Title = "Mercedes CLK", Fuel = Models.FuelType.Diesel, Price = 12000, New = true, Mileage = 150000, FirstRegistration = DateTime.Parse("06.06.2006")},
        };

        #region GET
        [TestMethod]
        public void Get()
        {
            // Arrange
            CarAdvertController controller = new CarAdvertController();
            controller.DummyAdvertList = TestAdvertList.ToList();
            // Act
            IEnumerable<CarAdvertViewModel> result = controller.GetAll();
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(6, result.Count());
            Assert.AreEqual(TestAdvertList.FirstOrDefault(), result.ElementAt(0));
            Assert.AreEqual(TestAdvertList.LastOrDefault(), result.ElementAt(5));
        }

        [TestMethod]
        public void GetSortedByMileage()
        {
            // Arrange
            CarAdvertController controller = new CarAdvertController();
            controller.DummyAdvertList = TestAdvertList.ToList();
            // Act
            IEnumerable<CarAdvertViewModel> result = controller.GetAll("mileage");
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(TestAdvertList.ElementAtOrDefault(4), result.ElementAt(1));
            Assert.AreEqual(TestAdvertList.ElementAtOrDefault(2), result.ElementAt(2));
        }

        [TestMethod]
        public void GetSortedByTitle()
        {
            // Arrange
            CarAdvertController controller = new CarAdvertController();
            controller.DummyAdvertList = TestAdvertList.ToList();
            // Act
            IEnumerable<CarAdvertViewModel> result = controller.GetAll("title");
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(TestAdvertList.ElementAtOrDefault(4), result.ElementAt(0));
            Assert.AreEqual(TestAdvertList.ElementAtOrDefault(0), result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            CarAdvertController controller = new CarAdvertController();
            controller.DummyAdvertList = TestAdvertList.ToList();
            // Act
            CarAdvertViewModel result = controller.GetAdvertById(5);
            // Assert
            Assert.AreEqual(TestAdvertList.ElementAtOrDefault(4), result);
        }
        #endregion GET


        [TestMethod]
        public void Post()
        {
            // Arrange
            CarAdvertController controller = new CarAdvertController();
            controller.DummyAdvertList = TestAdvertList.ToList();
            // Act
            CarAdvertViewModel newAdvert = new CarAdvertViewModel(7);
            controller.PostAdvert(newAdvert);
            IEnumerable<CarAdvertViewModel> result = controller.GetAll();
            // Assert
            Assert.AreEqual(7, result.Count());
            Assert.AreEqual(newAdvert.Title, result.ElementAt(6).Title);
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            CarAdvertController controller = new CarAdvertController();
            controller.DummyAdvertList = TestAdvertList.ToList();
            // Act
            CarAdvertViewModel putAdvert = new CarAdvertViewModel(5);
            controller.PutAdvert(5, putAdvert);
            IEnumerable<CarAdvertViewModel> result = controller.GetAll();
            // Assert
            Assert.AreEqual(6, result.Count());
            Assert.AreEqual(putAdvert.Title, result.ElementAt(4).Title);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            CarAdvertController controller = new CarAdvertController();
            controller.DummyAdvertList = TestAdvertList.ToList();
            // Act
            CarAdvertViewModel oldAdvertOne = controller.GetAdvertById(1);
            CarAdvertViewModel oldAdvertTwo = controller.GetAdvertById(2);
            controller.DeleteAdvert(1);
            IEnumerable<CarAdvertViewModel> result = controller.GetAll();
            // Assert
            Assert.AreEqual(5, result.Count());
            Assert.AreNotEqual(oldAdvertOne, result.ElementAt(0));
            Assert.AreEqual(oldAdvertTwo, result.ElementAt(0));
        }
    }
}
