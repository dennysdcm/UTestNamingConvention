using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UTestNamingConvention.Core;

namespace UTestNamingConvention.Test.OptionThree.PricingCalculatorTests
{
    [TestClass]
    public class PricingCalculatorCalculate

    {
        private Customer customer;
        private PricingCalculator pricingCalculator;

        [TestInitialize]
        public void Setup()
        {
            pricingCalculator = new PricingCalculator();
        }

        [TestMethod]
        public void ReturnPriceLessPreferredCustomerDiscountGivenPreferredCustomerAndQuatityGreatherThanOne()
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
        public void ReturnPriceTimesQuantityGivenRegularCustomerAndQuantityGreaterThanOne()
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
        public void ReturnZeroGivenQuantityZero()
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
        public void ThrowArgumentOutOfRangeExceptionGivenQuantityLessThanZero()
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
