using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;

namespace Tester.Meta.Algorithms.FirstTask
{
    public class FourthAlgorithm : IAlgorithm
    {
        public string Name => nameof(FourthAlgorithm);

        public double Calculate(Vector vector, double x, int index = 0)
        {
            if (index == vector.Count) return 0;
            return vector[index] + x * Calculate(vector, x, index + 1);
        }

        public void TestRun(object[] @params)
        {
            Calculate(@params[0] as Vector, (int)@params[1]);
        }
    }
}
