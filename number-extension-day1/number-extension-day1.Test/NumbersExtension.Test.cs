using NUnit.Framework;
using System;

namespace number_extension_day1.Test
{
    public class NumbersExtensionTest
    {
        [TestCase(2728, 655, 3, 8, ExpectedResult = 2680)]
        [TestCase(554216104, 15, 0, 31, ExpectedResult = 15)]
        [TestCase(-55465467, 345346, 0, 31, ExpectedResult = 345346)]
        [TestCase(554216104, 4460559, 11, 18, ExpectedResult = 554203816)]
        [TestCase(-1, 0, 31, 31, ExpectedResult = 2147483647)]
        [TestCase(-2147483648, 2147483647, 0, 30, ExpectedResult = -1)]
        [TestCase(-2223, 5440, 18, 23, ExpectedResult = -16517295)]
        [TestCase(2147481425, 5440, 18, 23, ExpectedResult = 2130966353)]
        public int InsertNumber_ValidInputs_ReturnsExpected(int source, int insert, int i, int j)
        {
            return NumbersExtension.InsertNumberIntoAnother(source, insert, i, j);
        }

        [Test]
        public void InsertNumber_InvalidRange_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                NumbersExtension.InsertNumberIntoAnother(8, 15, 8, 3));
        }

        [Test]
        public void InsertNumber_NegativeIndex_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                NumbersExtension.InsertNumberIntoAnother(8, 15, -1, 3));
        }

        [Test]
        public void InsertNumber_IndexTooLarge_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                NumbersExtension.InsertNumberIntoAnother(8, 15, 32, 32));
        }

        [Test]
        public void InsertNumber_EndIndexTooLarge_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                NumbersExtension.InsertNumberIntoAnother(8, 15, 0, 32));
        }
    }
}