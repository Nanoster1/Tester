using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;

namespace Tester.Meta.Testers
{
    public class MemoryTester : ITester<long>
    {
        public MemoryTester()
        {
            AllResults = new List<TestResult<long>>();
        }
        public TestResult<long> LastResult { get; private set; }

        public IList<TestResult<long>> AllResults { get; private set; }

        public void Test(Action algorithm, int iterationNumber, string name)
        {
            long result = 0;
            var localResults = new long[iterationNumber];
            for (int i = 0; i < iterationNumber; i++)
            {
                var startMemory = GC.GetTotalMemory(false);
                algorithm.Invoke();
                var endMemory = GC.GetTotalMemory(false);
                result = result + endMemory - startMemory;
            }
            result = result < 0 ? LastResult.Result : result /= iterationNumber;
            var resultID = AllResults.Count(x => x.AlgorithmName == name) + 1;
            TestResult<long> testResult = new(resultID, result,localResults, name);
            LastResult = testResult;
            lock (AllResults)
            {
                AllResults.Add(testResult);
            }
        }
    }
}
