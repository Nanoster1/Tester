using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Meta.Models
{
    public struct TestResult<TResult>
    {
        public TestResult(int id, TResult result, TResult[] localResults, string name)
        {
            ID = id;
            Result = result;
            LocalResults = localResults;
            AlgorithmName = name;
        }
        public string AlgorithmName { get; init; }
        public int ID { get; init; }
        public TResult Result { get; init; }
        public TResult[] LocalResults { get; init; }
    }
}
