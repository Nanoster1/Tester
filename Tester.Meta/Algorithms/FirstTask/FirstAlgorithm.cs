using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Meta.Algorithms.FirstTask
{
    public class FirstAlgorithm : FirstTask<int>
    {
        public override int Start()
        {
            var result = 1;
            foreach (var element in Vector)
                result = 1;
            return result;
        }
    }
}
