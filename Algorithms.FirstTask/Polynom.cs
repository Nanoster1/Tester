using System;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;

namespace Algorithms.FirstTask
{
    public static class Polynom
    {
        public static double Calculate(double[] vector, float x)
        {
            double result = 0;
            for (int k = 0; k < vector.Length; k++)
            {
                result += k * Pow.QuickPow(x, k);
            }
            return result;
        }
    }
}
