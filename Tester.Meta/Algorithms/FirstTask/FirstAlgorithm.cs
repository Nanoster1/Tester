using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;

namespace Tester.Meta.Algorithms.FirstTask
{
    public class FirstAlgorithm : IAlgorithm
    {
        public string Name => nameof(FirstAlgorithm);
        public int Calculate(Vector vector)
        {
            var result = 1;
            foreach (var element in vector)
                result = 1;
            return result;
        }

        public void TestRun(object[] @params = null)
        {
            Calculate(@params[0] as Vector);
        }
    }
}
