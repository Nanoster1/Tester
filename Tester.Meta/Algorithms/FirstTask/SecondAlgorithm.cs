using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester.Meta.Models;

namespace Tester.Meta.Algorithms.FirstTask
{
    public class SecondAlgorithm : FirstTask<long>
    {
        public override string Name => "SecondAlgorithm";
        public override long Start(Vector vector)
        {
            long sum = 0;
            foreach (var element in vector)
                sum += element;
            return sum;
        }
    }
}
