using System;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;

namespace Algorithms.FirstTask
{
    public static class Polynom
    {
        public static double Calculate(double[] vector, double x)
        {
            double result = 0;
            for (int k = 0; k < vector.Length; k++)
            {
                result += vector[k] * Pow.QuickPow(x, k);
            }
            return result;
        }
    }
}
