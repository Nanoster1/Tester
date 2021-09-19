using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Meta.Models
{
    public struct TestResult<TResult>
    {
        public TestResult(int id, TResult result, string name)
        {
            ID = id;
            Result = result;
            AlgorithmName = name;
        }
        public string AlgorithmName { get; init; }
        public int ID { get; init; }
        public TResult Result { get; init; }
    }
}
