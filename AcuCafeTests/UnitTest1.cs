using AcuCafe;
using NUnit.Framework;
using System;

namespace AcuCafeTests
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase("Expresso", false, false, 1.8)]
        [TestCase("Expresso", false, true, 2.3)]
        [TestCase("Expresso", true, true, 2.8)]
        [TestCase("HotTea", false, false, 1)]
        [TestCase("HotTea", false, true, 1.5)]
        [TestCase("HotTea", true, true, 2.0)]
        [TestCase("IceTea", false, false, 1.5)]
        [TestCase("IceTea", false, true, 2.0)]
        public void TestCosts(string type, bool hasMilk, bool hasSugar,double expectedCost)
        {
            var drink = AcuCafe.AcuCafe.OrderDrink(type, hasMilk, hasSugar);
            Assert.AreEqual(expectedCost, drink.Cost());
        }
    }
}
