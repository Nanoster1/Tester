using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;

namespace Tester.Meta.Algorithms.FirstTask
{
    public class SecondAlgorithm : IAlgorithm
    {
        public string Name => nameof(SecondAlgorithm);
        public long Calculate(Vector vector)
        {
            long sum = 0;
            foreach (var element in vector)
                sum += element;
            return sum;
        }

        public void TestRun(object[] @params = null)
        {
            Calculate(@params[0] as Vector);
        }
    }
}
