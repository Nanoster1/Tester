using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester.Meta.Models;

namespace Tester.Meta.Interfaces
{
    public interface ITester<TResult>
    {
        public void Test(IAlgorithm algorithm, int iterationNumber, object[] @params);
        public TestResult<TResult> LastResult { get; }
        public List<TestResult<TResult>> AllResults { get; }
    }
}
