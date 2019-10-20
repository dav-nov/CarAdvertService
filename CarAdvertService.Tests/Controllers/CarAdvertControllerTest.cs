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
        [TestMethod]
        public void Get()
        {
            // Arrange
            CarAdvertController controller = new CarAdvertController();

            // Act
            IEnumerable<CarAdvertViewModel> result = controller.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            CarAdvertController controller = new CarAdvertController();

            // Act
            CarAdvertViewModel result = controller.GetAdvertById(5);

            // Assert
            Assert.AreEqual(5, result.Id);
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
