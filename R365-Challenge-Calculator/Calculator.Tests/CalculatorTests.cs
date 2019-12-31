using CalculatorService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Caculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator _calculator;

        public CalculatorTests()
        {
            _calculator =  new Calculator();
        }

        [TestMethod]
        public void Add_20_Return20()
        {
            //Arrange
            string input = "20";

            //Act
            var result = _calculator.Add(input);
            int expect = 20;

            //Assert
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void Add_1_plus_500_Return501()
        {
            //Arrange
            string input = "1,500";

            //Act
            var result = _calculator.Add(input);
            int expect = 501;

            //Assert
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void Add_4_minus_3_Return1()
        {
            //Arrange
            string input = "4,-3";

            //Act
            var result = _calculator.Add(input);
            int expect = 1;

            //Assert
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void Add_ThrowAnExceptionWhenMoreThanTwoNumbers()
        {
            //Arrange
            string input = "4,3,7";

            //Act

            //Assert
            Assert.ThrowsException<Exception>(() => _calculator.Add(input));

        }

        [TestMethod]
        public void Add_EmptyInputConvertToZero()
        {
            //Arrange
            string input = "";

            //Act
            var result = _calculator.Add(input);
            int expect = 0;

            //Assert
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void Add_MissingNumbersConvertToZero()
        {
            //Arrange
            string input = "100,";

            //Act
            var result = _calculator.Add(input);
            int expect = 100;

            //Assert
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void Add_InvalidNumbersConvertToZero()
        {
            //Arrange
            string input = "5,tyty";

            //Act
            var result = _calculator.Add(input);
            int expect = 5;

            //Assert
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void Add_RemoveMaxConstrainNumbers_Return78()
        {
            //Arrange
            string input = "1,2,3,4,5,6,7,8,9,10,11,12";

            //Act
            var result = _calculator.Add(input);
            int expect = 78;

            //Assert
            Assert.AreEqual(expect, result);
        }
    }
}
