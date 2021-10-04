using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Meta.Models
{
    public record TestResult<TResult>
    {
        public TestResult(int id, string name, TResult result, TResult[] localResults)
        {
            ID = id;
            AlgorithmName = name;
            Result = result;
            LocalResults = localResults;
        }
        public string AlgorithmName { get; init; }
        public int ID { get; init; }
        public TResult Result { get; init; }
        public TResult[] LocalResults { get; init; }
    }
}
