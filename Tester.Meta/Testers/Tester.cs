using System.Collections.Generic;
using System.Threading.Tasks;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;

namespace Tester.Meta.Testers
{
    public abstract class Tester<TResult>
    {
        public abstract void Test(IAlgorithm algorithm, int iterationNumber, object[] @params);
        public abstract TestResult<TResult> LastResult { get; protected set; }
        public abstract List<TestResult<TResult>> AllResults { get; protected set; }

        /* public virtual async void TestAsync(IAlgorithm algorithm, int iterationNumber, object[] algParams) => 
            await Task.Run(() => Test(algorithm, iterationNumber, algParams));*/
    }
}