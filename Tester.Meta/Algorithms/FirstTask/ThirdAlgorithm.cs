using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector = Tester.Meta.Models.Vector;

namespace Tester.Meta.Algorithms.FirstTask
{
    public class ThirdAlgorithm : FirstTask<BigInteger>
    {
        public override string Name => "ThirdAlgorithm";
        public override BigInteger Start(Vector vector)
        {
            BigInteger value = new(1);
            foreach (var element in vector)
                value *= element;
            return value;
        }
    }
}
