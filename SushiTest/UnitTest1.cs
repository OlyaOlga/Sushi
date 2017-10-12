using System;
using ConsoleSushi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SushiTest
{
    [TestClass]
    public class SushiUnitTests
    {
        [TestMethod]
        public void TestChangePriceFromSushiItem()
        {
            SushiItem item = new SushiItem("item", 10.7);
            double newPrice = 11.2;
            item.ChangePrice(newPrice);
            Assert.AreEqual(item.Price, newPrice);
        }
        [TestMethod]
        public void TestAddItemFromAvaliableSushi()
        {
            AvaliableSushi sushi = new AvaliableSushi();
            SushiItem toAdd = new SushiItem("name", 12);
            sushi.AddItem(toAdd);
            Assert.IsTrue(ReferenceEquals(toAdd, sushi.AllSushiItems[0]));
        }
        [TestMethod]
        public void TestRemoveItemFromAvaliableSushi()
        {
            AvaliableSushi sushi = new AvaliableSushi();
            SushiItem toAddFirst = new SushiItem("name", 12);
            SushiItem toAddSecond = new SushiItem("name1", 12);
            sushi.AddItem(toAddFirst);
            sushi.AddItem(toAddSecond);
            sushi.RemoveItem(toAddFirst);
            Assert.AreEqual(sushi.AllSushiItems.Count, 1);
        }
        [TestMethod]
        public void TestAddOrderItemFromOrder()
        {
            Order myOrder = new Order();
            SushiItem item = new SushiItem("name", 12.8);
            uint quantity = 12;
            myOrder.AddOrderItem(item, quantity);
            Assert.IsTrue(myOrder.CurrentOrder.ContainsKey(item) && myOrder.CurrentOrder.ContainsValue(quantity));
        }
        [TestMethod]
        public void TestAddOrderItemAddExistingItemFromOrder()
        {
            Order myOrder = new Order();
            SushiItem item = new SushiItem("name", 12.8);
            uint quantity = 12;
            myOrder.AddOrderItem(item, quantity);
            myOrder.AddOrderItem(item, quantity);
            Assert.IsTrue(myOrder.CurrentOrder.ContainsKey(item) && myOrder.CurrentOrder.ContainsValue(quantity*2));
        }
        [TestMethod]
        public void TestCheckTotalSumFromOrder()
        {
            Order myOrder = new Order();
            double firstPrice = 12.8;
            SushiItem firstItem = new SushiItem("name", firstPrice);
            uint firstQuantity = 12;
            myOrder.AddOrderItem(firstItem, firstQuantity);

            double secondPrice = 15;
            SushiItem secondItem = new SushiItem("name", secondPrice);
            uint secondQuantity = 10;
            myOrder.AddOrderItem(secondItem, secondQuantity);

            Assert.AreEqual(myOrder.TotalSum, firstPrice*firstQuantity+secondPrice*secondQuantity);
        }
    }
     [TestClass]
    public class IngredientsUnitTest
    {
        [TestMethod]
        public void TestChangePriceFromFoodItem()
        {
            FoodItem item = new FoodItem("fish", 100);
            double newPrice = 120;
            item.ChangePrice(newPrice);
            Assert.AreEqual(item.Price, newPrice);
        }
    }
}
