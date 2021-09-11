using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Meta.Algorithms.FirstTask
{
    public class ThirdAlgorithm : FirstTask<BigInteger>
    {
        public override BigInteger Start()
        {
            BigInteger value = new(1);
            foreach (var element in Vector)
                value *= element;
            return value;
        }
    }
}
