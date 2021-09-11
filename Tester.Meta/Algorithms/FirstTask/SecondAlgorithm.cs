using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Meta.Algorithms.FirstTask
{
    public class SecondAlgorithm : FirstTask<long>
    {
        public override long Start()
        {
            long sum = 0;
            foreach (var element in Vector)
                sum += element;
            return sum;
        }
    }
}
