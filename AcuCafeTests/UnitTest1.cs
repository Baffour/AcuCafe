using AcuCafe;
using NUnit.Framework;
using System;

namespace AcuCafeTests
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase("Expresso", new Topping[] { }, 1.8)]
        [TestCase("Expresso", new[] { Topping.Sugar }, 2.3)]
        [TestCase("Expresso", new[] { Topping.Sugar, Topping.Milk }, 2.8)]
        [TestCase("Expresso", new[] { Topping.Sugar, Topping.Milk,Topping.Chocolate }, 3.4)]
        [TestCase("HotTea", new Topping[] { }, 1)]
        [TestCase("HotTea", new[] { Topping.Sugar }, 1.5)]
        [TestCase("HotTea", new[] { Topping.Sugar, Topping.Milk }, 2.0)]
        [TestCase("IceTea", new Topping[] { }, 1.5)]
        [TestCase("IceTea", new[] { Topping.Sugar }, 2.0)]
        public void TestCosts(string type, Topping[] toppings, decimal expectedCost)
        {
            var drink = AcuCafe.AcuCafe.OrderDrink(type, toppings);
            Assert.AreEqual(expectedCost, drink.Cost());
        }
        [TestCase]
        public void TestInvalidType()
        {
            var invalidType = "InvalidType";
            TestDelegate orderDrink = () => AcuCafe.AcuCafe.OrderDrink(invalidType, new Topping[] { });
            var exception = Assert.Catch<ArgumentException>(orderDrink);
            var expectedMessage = string.Format(Constants.InvalidTypeExceptionMessage, invalidType);
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestCase("IceTea", new[] { Topping.Milk, Topping.Sugar }, Topping.Milk)]
        [TestCase("IceTea", new[] { Topping.Milk }, Topping.Milk)]
        [TestCase("HotTea", new[] { Topping.Chocolate }, Topping.Chocolate)]
        public void TestInvalidToppingForDrink(string type, Topping[] toppings, Topping expectedInvalidTopping)
        {
            TestDelegate orderDrink = () => AcuCafe.AcuCafe.OrderDrink(type, toppings);
            var exception = Assert.Catch<InvalidOperationException>(orderDrink);
            var expectedMessage = string.Format(Constants.InvalidToppingExceptionMessage, type, expectedInvalidTopping);
            Assert.AreEqual(expectedMessage, exception.Message);
        }
    }
}
