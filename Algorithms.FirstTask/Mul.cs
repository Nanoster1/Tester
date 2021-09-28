using Tester.Meta.Models;

namespace Algorithms.FirstTask
{
    public static class Mul
    {
        public static double Calculate(double[] vector)
        {
            double result = 1;
            foreach (var element in vector)
            {
                result *= element;
            }
            return result;
        }
    }
}
