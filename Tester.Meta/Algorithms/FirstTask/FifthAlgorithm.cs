using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;

namespace Tester.Meta.Algorithms.FirstTask
{
    public class FifthAlgorithm : IAlgorithm
    {
        public string Name => nameof(FifthAlgorithm);

        public void Sort(Vector vector)
        {
            for(int i = 0; i < vector.Count; i++)
            {
                for(int k = i + 1; k < vector.Count; k++)
                {
                    if (vector[i] > vector[k])
                    {
                        var temp = vector[i];
                        vector[i] = vector[k];
                        vector[k] = temp;
                    }
                }
            }
        }

        public void TestRun(object[] @params = null)
        {
            Sort(@params[0] as Vector);
        }
    }
}
