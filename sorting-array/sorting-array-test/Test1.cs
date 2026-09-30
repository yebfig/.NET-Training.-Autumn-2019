using Microsoft.VisualStudio.TestTools.UnitTesting;
using sorting_array;

namespace sorting_array_test
{
    [TestClass]
    public sealed class ArrayExtensionTests
    {
        [TestMethod]
        public void BubbleSort_SortsEvenIndicesByAbsoluteValue()
        {
            int[] array = { -5, 10, 3, 20, -2, 30, 1 };

            ArrayExtension.BubbleSort(
                ref array,
                new AbsKey(),
                new IsIndexEvenCondition()
            );

            int[] expected = { 1, 10, -2, 20, 3, 30, -5 };

            CollectionAssert.AreEqual(expected, array);
        }
    }
}
