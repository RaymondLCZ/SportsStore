using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;
using SportsStore.WebUI.HtmlHelpers;
using System.Web.Mvc;
using System.Linq;

namespace SportsStore.UnitTest
{
    [TestClass]
    public class Test_ProductController
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

        [TestCategory("Product Controller")]
        [TestMethod]
        public void Can_Paginate()
        {
            // create controller and set page size equal 3
            ProductController controller = new ProductController(mock.Object);
            controller.pageSize = 3;

            // Act
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;

            // Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
        }

        [TestCategory("Product Controller")]
        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            ProductController controller = new ProductController(mock.Object);
            controller.pageSize = 3;

            // Act
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;

            //
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPage, 2);
            Assert.AreEqual(pageInfo.CurrentPage, 2);
        }

        [TestCategory("Product Controller")]
        [TestMethod]
        public void Can_Filter_Products()
        {
            ProductController controller = new ProductController(mock.Object);
            controller.pageSize = 3;

            ProductsListViewModel result = (ProductsListViewModel)controller.List("Cat2", 1).Model;
            Product[] prodArray = result.Products.ToArray();

            Assert.IsTrue(prodArray.Length == 2);

        }
    }
}
