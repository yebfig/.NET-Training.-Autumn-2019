using System;
using NUnit.Framework;

namespace day3_practice_tasks;

[TestFixture]
public class MathExtensionTest
{
    [TestCase(1, 5, 0.0001, ExpectedResult = 1.0)]
    [TestCase(8, 3, 0.0001, ExpectedResult = 2.0)]
    [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
    [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
    [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
    [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
    [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
    [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
    public double FindNthRoot_ValidArguments_ReturnsCorrectResult(double num, double n, double eps)
    {
        double result = MathExtension.FindNthRoot(num, n, eps);
        return Math.Round(result, GetDecimalPlaces(eps));
    }

    [TestCase(-0.01, 2, 0.0001)]
    [TestCase(0.001, -2, 0.0001)]
    [TestCase(0.01, 2, -1.0)]
    public void FindNthRoot_InvalidArguments_ThrowsArgumentException(double num, double n, double eps)
    {
        Assert.Throws<ArgumentException>(() => MathExtension.FindNthRoot(num, n, eps));
    }

    private int GetDecimalPlaces(double eps)
    {
        if (eps <= 0) return 0;
        return Math.Max(0, (int)Math.Ceiling(-Math.Log10(eps)));
    }
}
