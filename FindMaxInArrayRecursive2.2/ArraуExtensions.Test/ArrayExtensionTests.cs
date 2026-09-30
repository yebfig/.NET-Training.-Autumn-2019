using NUnit.Framework;
using ArrayExtensions;

namespace ArrayExtensions.Tests
{
    public class ArrayExtensionTests
    {
        // =========================
        // FilterArrayByKey
        // =========================

        [TestCase(
            new[] { 2212332, 1405644, -1236674 },
            0,
            new[] { 1405644 })]

        [TestCase(
            new[] { 53, 71, -24, 1001, 32, 1005 },
            2,
            new[] { -24, 32 })]

        [TestCase(
            new[] { -27, 173, 371132, 7556, 7243, 10017 },
            7,
            new[] { -27, 173, 371132, 7556, 7243, 10017 })]

        [TestCase(
            new[] { 7, 2, 5, 5, -1, -1, 2 },
            9,
            new int[0])]

        public void FilterArrayByKey_ReturnsExpectedArray(
            int[] array,
            int key,
            int[] expected)
        {
            int[] actual = array.FilterArrayByKey(key);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FilterArrayByKey_NullArray_ThrowsArgumentNullException()
        {
            int[] array = null;

            Assert.Throws<ArgumentNullException>(
                () => array.FilterArrayByKey(5));
        }

        [Test]
        public void FilterArrayByKey_InvalidKey_ThrowsArgumentOutOfRangeException()
        {
            int[] array = { 1, 2, 3 };

            Assert.Throws<ArgumentOutOfRangeException>(
                () => array.FilterArrayByKey(10));
        }

        [Test]
        public void FilterArrayByKey_NegativeKey_ThrowsArgumentOutOfRangeException()
        {
            int[] array = { 1, 2, 3 };

            Assert.Throws<ArgumentOutOfRangeException>(
                () => array.FilterArrayByKey(-1));
        }

        [Test]
        public void FilterArrayByKey_EmptyArray_ThrowsArgumentException()
        {
            int[] array = Array.Empty<int>();

            Assert.Throws<ArgumentException>(
                () => array.FilterArrayByKey(5));
        }

        [Test]
        public void FilterArrayByKey_Zero_IsFoundInZero()
        {
            int[] array = { 0, 1, 2 };

            int[] actual = array.FilterArrayByKey(0);

            Assert.That(actual, Is.EqualTo(new[] { 0 }));
        }

        [Test]
        public void FilterArrayByKey_MinValue_DoesNotThrow()
        {
            int[] array = { int.MinValue };

            int[] actual = array.FilterArrayByKey(8);

            Assert.That(actual, Is.EqualTo(new[] { int.MinValue }));
        }


        // =========================
        // FindMaximumItem
        // =========================

        [Test]
        public void FindMaximumItem_ReturnsMaximum()
        {
            int[] array = { 3, 8, 2, 10, 5 };

            int actual = array.FindMaximumItem();

            Assert.That(actual, Is.EqualTo(10));
        }

        [Test]
        public void FindMaximumItem_WorksWithNegativeNumbers()
        {
            int[] array = { -10, -5, -20, -3, -15 };

            int actual = array.FindMaximumItem();

            Assert.That(actual, Is.EqualTo(-3));
        }

        [Test]
        public void FindMaximumItem_WorksWithOneElement()
        {
            int[] array = { 42 };

            int actual = array.FindMaximumItem();

            Assert.That(actual, Is.EqualTo(42));
        }

        [Test]
        public void FindMaximumItem_WorksWithDuplicateMaximum()
        {
            int[] array = { 5, 2, 10, 10, 3 };

            int actual = array.FindMaximumItem();

            Assert.That(actual, Is.EqualTo(10));
        }

        [Test]
        public void FindMaximumItem_NullArray_ThrowsArgumentNullException()
        {
            int[] array = null;

            Assert.Throws<ArgumentNullException>(
                () => array.FindMaximumItem());
        }

        [Test]
        public void FindMaximumItem_EmptyArray_ThrowsArgumentException()
        {
            int[] array = Array.Empty<int>();

            Assert.Throws<ArgumentException>(
                () => array.FindMaximumItem());
        }


        // =========================
        // FindBalanceIndex
        // =========================

        [Test]
        public void FindBalanceIndex_ReturnsCorrectIndex()
        {
            int[] array = { 1, 2, 3, 6, 6 };

            int? actual = array.FindBalanceIndex();

            Assert.That(actual, Is.EqualTo(3));
        }

        [Test]
        public void FindBalanceIndex_ReturnsNullWhenIndexDoesNotExist()
        {
            int[] array = { 1, 2, 3 };

            int? actual = array.FindBalanceIndex();

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void FindBalanceIndex_OneElement_ReturnsZero()
        {
            int[] array = { 10 };

            int? actual = array.FindBalanceIndex();

            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void FindBalanceIndex_EmptyArray_ReturnsNull()
        {
            int[] array = Array.Empty<int>();

            int? actual = array.FindBalanceIndex();

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void FindBalanceIndex_WorksWithNegativeNumbers()
        {
            int[] array = { 1, 2, -3, 2, 1 };

            int? actual = array.FindBalanceIndex();

            Assert.That(actual, Is.EqualTo(2));
        }

        [Test]
        public void FindBalanceIndex_NullArray_ThrowsArgumentNullException()
        {
            int[] array = null;

            Assert.Throws<ArgumentNullException>(
                () => array.FindBalanceIndex());
        }
    }
}