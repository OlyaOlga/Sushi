using System;
using ConsoleSushi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SushiTest
{
    [TestClass]
    public class SushiUnitTests
    {
        [TestMethod]
        public void TestChangePriceSushiItem()
        {
            SushiItem item = new SushiItem("item", 10.7);
            double newPrice = 11.2;
            item.ChangePrice(newPrice);
            Assert.AreEqual(item.Price, newPrice);
        }
        [TestMethod]
        public void TestChangePriceFoodItem()
        {
            FoodItem item = new FoodItem("fish", 100);
            double newPrice = 120;
            item.ChangePrice(newPrice);
            Assert.AreEqual(item.Price, newPrice);
        }
        [TestMethod]
        public void TestAddItem()
        {
            PossibleVariants<FoodItem> foodItem = new PossibleVariants<FoodItem>();
            FoodItem toAdd = new FoodItem("name", 12);
            foodItem.AddItem(toAdd);
            Assert.IsTrue(ReferenceEquals(toAdd, foodItem.AllPossibleItems[0]));
        }
        [TestMethod]
        public void TestRemoveItem()
        {
            PossibleVariants<SushiItem> sushi = new PossibleVariants<SushiItem>();
            SushiItem toAddFirst = new SushiItem("name", 12);
            SushiItem toAddSecond = new SushiItem("name1", 12);
            sushi.AddItem(toAddFirst);
            sushi.AddItem(toAddSecond);
            sushi.RemoveItem(toAddFirst);
            Assert.AreEqual(sushi.AllPossibleItems.Count, 1);
        }

        [TestMethod]
        public void TestOrderEntityConstructor()
        {
            string sushiName = "sushiName";
            double price = 10;
            SushiItem item = new SushiItem(sushiName, price);
            uint quantity = 30;
            OrderEntity<SushiItem> testEntity = new OrderEntity<SushiItem>(item, quantity);
            Assert.IsTrue(item.Equals(testEntity.Value)&&quantity.Equals(testEntity.Quantity));
        }

        [TestMethod]
        public void TestAddOrderItemFromOrder()
        {
            CurrentOrder<SushiItem> myOrder = new CurrentOrder<SushiItem>();
            SushiItem item = new SushiItem("name", 12.8);
            uint quantity = 12;
            myOrder.OrderSomething(item, quantity);
            Assert.IsTrue(myOrder.Order.Contains(new OrderEntity<SushiItem>(item, quantity)));
        }
        
        [TestMethod]
        public void TestCancelOrder()
        {
           CurrentOrder<SushiItem> order = new CurrentOrder<SushiItem>();
           SushiItem item = new SushiItem("name", 12.8);
           uint quantity = 12;
           order.OrderSomething(item, quantity);
           OrderEntity<SushiItem> thisOrder  =new OrderEntity<SushiItem>(item, quantity);
           order.CancelOrder(thisOrder);
           Assert.IsTrue(order.TotalSum==0.00 && order.Order.Count == 0);
        }
        
        [TestMethod]
        public void TestChangeOrder()
        {
            CurrentOrder<SushiItem> myOrder = new CurrentOrder<SushiItem>();
            double price = 12.8;
            SushiItem item = new SushiItem("name", price);
            uint quantity = 12;
            myOrder.OrderSomething(item, quantity);
            uint newQuantity = quantity +1;
            myOrder.ChangeOrder(new OrderEntity<SushiItem>(item, quantity), newQuantity);
            Assert.AreEqual(myOrder.TotalSum, item.Price* newQuantity);
        }
        
    }
}
