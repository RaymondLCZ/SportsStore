using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace SportsStore.UnitTest
{
    [TestClass]
    public class Test_NavController
    {
        Mock<IProductRepository> mock;

        [TestInitialize]
        public void InitializeMock()
        {
            mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1", Category = "Cat1" },
                new Product {ProductID = 2, Name = "P2", Category = "Cat2"  },
                new Product {ProductID = 3, Name = "P3", Category = "Cat1"  },
                new Product {ProductID = 4, Name = "P4", Category = "Cat2"  },
                new Product {ProductID = 5, Name = "P5", Category = "Cat3"  }
            });
        }

        [TestMethod]
        public void Can_Create_Categories()
        {
            NavController controller = new NavController(mock.Object);

            string[] result = ((IEnumerable<String>)controller.Menu().Model).ToArray();

            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual(result[0], "Cat1");
        }
        
        [TestMethod]
        public void Indicates_Selected_Category()
        {
            NavController target = new NavController(mock.Object);

            string categoryToSelected = "Cat2";

            string result = target.Menu(categoryToSelected).ViewBag.SelectedCategory;

            Assert.AreEqual(categoryToSelected, result);
        }
    }
}
