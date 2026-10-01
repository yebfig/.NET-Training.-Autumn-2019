using System.Numerics;

namespace day3_practice_tasks
{
    //x_next = (1 / n) * ((n - 1) * x + A / (x ** (n - 1)))
    public static class MathExtension
    {
        public static double FindNthRoot(double num, double n, double eps)
        {
            if (num == 0) return 0;

            if (eps <= 0 || n <= 0 || ((num < 0) && (n % 2 == 0)))
                throw new ArgumentException("Arguments aren't correct");

            double x = num;
            double xNext;

            while (true)
            {
                xNext = (1 / n) * ((n - 1) * x + num / Math.Pow(x, n - 1));
                if (Math.Abs(x - xNext) < eps)
                {
                    break;
                }
                x = xNext;
            }

            return xNext;
        }
    }
}

