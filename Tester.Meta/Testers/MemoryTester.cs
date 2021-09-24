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
            long[] localResults = new long[iterationNumber];

            for (int i = 0; i < iterationNumber; i++)
            {
                var startMemory = GC.GetTotalMemory(false);
                GC.TryStartNoGCRegion(2097152);
                algorithm.Invoke();
                var endMemory = GC.GetTotalMemory(false);
                try { GC.EndNoGCRegion(); } catch { }

                localResults[i] = endMemory - startMemory;
                if (i > 0 && localResults[i] < 0)
                    localResults[i] = localResults[i - 1];
            }

            long result = localResults.Sum();
            result = result < 0 ? 0 : result / iterationNumber;

            var resultID = AllResults.Count(x => x.AlgorithmName == name) + 1;

            TestResult<long> testResult = new(resultID, name, result, localResults);
            LastResult = testResult;

            lock (AllResults)
            {
                AllResults.Add(testResult);
            }
        }
    }
}
