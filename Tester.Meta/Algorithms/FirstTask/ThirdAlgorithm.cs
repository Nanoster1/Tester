using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Tester.Meta.Interfaces;
using Vector = Tester.Meta.Models.Vector;

namespace Tester.Meta.Algorithms.FirstTask
{
    public class ThirdAlgorithm : IAlgorithm
    {
        public string Name => nameof(ThirdAlgorithm);
        public BigInteger Calculate(Vector vector)
        {
            BigInteger value = new(1);
            foreach (var element in vector)
                value *= element;
            return value;
        }

        public void TestRun(object[] @params)
        {
            Calculate(@params[0] as Vector);
        }
    }
}
