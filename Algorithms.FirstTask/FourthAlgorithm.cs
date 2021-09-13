using System;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;

namespace Tester.Meta.Algorithms.FirstTask
{
    public class FourthAlgorithm : IAlgorithm
    {
        public string Name => nameof(FourthAlgorithm);

        public double Calculate(int[] vector)
        {
            double result = 0;
            for (int k = 0; k < vector.Length; k++)
            {
                result += k * Math.Pow(1.5, k);
            }
            return result;
        }

        public void TestRun(object[] @params)
        {
            Calculate((int[])@params[0]);
        }

        /* BigDecimal result = BigDecimal.ZERO;
            BigDecimal a;
            BigDecimal b;
            for (int k = 0; k < vector.Count; k++)
            {
                a = new BigDecimal(x).pow(k);
                b = new BigDecimal(vector[k]).multiply(a);
                result.add(b);
            }
            return result;*/
    }
}
