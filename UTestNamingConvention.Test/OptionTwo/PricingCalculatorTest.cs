using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UTestNamingConvention.Core;

namespace UTestNamingConvention.Test.OptionTwo
{
    [TestClass]
    public class PricingCalculatorTest
    {
        private Customer customer;
        private PricingCalculator pricingCalculator;

        [TestInitialize]
        public void Setup()
        {
            pricingCalculator = new PricingCalculator();
        }

        [TestMethod]
        public void Calculate_ReturnPriceLessPreferredCustomerDiscount_GivenPreferredCustomerAndQuatityGreatherThanOne()
        {
            // Arrange
            var units = 1;
            var unitPrice = 2.5m;
            customer = new Customer { IsPreferred = true };

            // Act
            var calculatedPrice = pricingCalculator.Calculate(units, customer, unitPrice);

            // Assert
            var expectedPrice = unitPrice * units * (1 - PricingCalculator.PreferredCustomerDiscount);
            Assert.AreEqual(expectedPrice, calculatedPrice);
        }

        [TestMethod]
        public void Calculate_ReturnPriceTimesQuantity_GivenRegularCustomerAndQuantityGreaterThanOne()
        {
            // Arrange
            var units = 1;
            var unitPrice = 2.5m;
            customer = new Customer { IsPreferred = false };

            // Act
            var calculatedPrice = pricingCalculator.Calculate(units, customer, unitPrice);

            // Assert
            var expectedPrice = unitPrice * units;
            Assert.AreEqual(expectedPrice, calculatedPrice);
        }

        [TestMethod]
        public void Calculate_ReturnZero_GivenQuantityZero()
        {
            // Arrange
            var units = 0;
            var unitPrice = 2.5m;
            customer = new Customer { IsPreferred = true };

            // Act
            var calculatedPrice = pricingCalculator.Calculate(units, customer, unitPrice);

            // Assert
            var expectedPrice = 0m;
            Assert.AreEqual(expectedPrice, calculatedPrice);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Calculate_ThrowArgumentOutOfRangeException_GivenQuantityLessThanZero()
        {
            // Arrange
            var units = -1;
            var unitPrice = 2.5m;
            customer = new Customer { IsPreferred = true };

            // Act
            var calculatedPrice = pricingCalculator.Calculate(units, customer, unitPrice);

            // Assert
            Assert.Fail("Should have thrown an exception");
        }
    }
}
