using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester.Meta.Models;

namespace Tester.Meta.Algorithms.FirstTask
{
    public class FirstAlgorithm : FirstTask<int>
    {
        public override string Name => "FirstAlgorithm";
        public override int Start(Vector vector)
        {
            var result = 1;
            foreach (var element in vector)
                result = 1;
            return result;
        }
    }
}
