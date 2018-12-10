using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// refs
using F2018Travel.Controllers;
using F2018Travel.Models;
using System.Web.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace F2018Travel.Tests.Controllers
{
    [TestClass]
    public class RegionsControllerTest
    {
        RegionsController controller;
        Mock<IMockRegions> mock;
        List<Region> regions;
        Region region;

        [TestInitialize]
        public void TestInitalize()
        {
            mock = new Mock<IMockRegions>();
            regions = new List<Region>
            {
                new Region { RegionId = 78, Region1 = "Oceania" },
                new Region { RegionId = 349, Region1 = "Eurasia" },
                new Region { RegionId = 205, Region1 = "Eastasia" },
            };

            region = new Region
            {
                RegionId = 489, Region1 = "Disputed"
            };

            mock.Setup(m => m.Regions).Returns(regions.AsQueryable());
            controller = new RegionsController(mock.Object);
        }
        [TestMethod]
        public void IndexViewLoads()
        {
            ViewResult result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod]
        public void IndexValidLoadsRegions()
        {
            var actual = (List<Region>)((ViewResult)controller.Index()).Model;

            CollectionAssert.AreEqual(regions.ToList(), actual);
        }
        [TestMethod]
        public void DetailsValidId()
        {
            Region actual = (Region)((ViewResult)controller.Details(349)).Model;

            Assert.AreEqual(regions[1], actual);
        }
        [TestMethod]
        public void DetailsInvalidId()
        {
            var result = (ViewResult)controller.Details(9999999);

            Assert.AreEqual("Error", result.ViewName);
        }
        [TestMethod]
        public void DetailsNoId()
        {
            var result = (ViewResult)controller.Details(null);

            Assert.AreEqual("Error", result.ViewName);
        }
    }
}
