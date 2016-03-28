using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using SportsStore.Domain.Entities;

namespace SportsStore.UnitTest
{
    [TestClass]
    public class Test_Cart
    {
        [TestMethod]
        public void Can_Add_New_Line()
        {
            Product prod1 = new Product { ProductID = 1, Name = "P1", Price = 100};
            Product prod2 = new Product { ProductID = 2, Name = "P2", Price = 50 };

            //Arrange
            Cart target = new Cart();

            target.AddItem(prod1, 1);
            target.AddItem(prod2, 1);
            CartLine[] lines = target.Lines.ToArray();

            //Assert
            Assert.AreEqual(lines.Length, 2);
        }
    }
}
