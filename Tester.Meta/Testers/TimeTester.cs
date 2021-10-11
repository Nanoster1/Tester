using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;

namespace Tester.Meta.Testers
{
    public class TimeTester : ITester<double>
    {
        public TimeTester()
        {
            AllResults = new List<TestResult<double>>();
        }

        public TestResult<double> LastResult { get; protected set; }
        public IList<TestResult<double>> AllResults { get; protected set; }

        public void Test(Action algorithm, int iterationNumber, string name)
        {
            var time = new Stopwatch();
            var localResults = new double[iterationNumber];
            for (int i = 0; i < iterationNumber; i++)
            {
                time.Restart();
                algorithm.Invoke();
                time.Stop();
                localResults[i] = time.Elapsed.TotalMilliseconds;
            }
            var resultID = AllResults.Count(x => x.AlgorithmName == name) + 1;
            var generalResult = localResults.Min();
            var testResult = new TestResult<double>(resultID, name, generalResult, localResults);
            LastResult = testResult;
            lock (AllResults) 
            {
                AllResults.Add(testResult); 
            }
        }
        
        public void SaveAsExcel(string path, string name, bool EmissionsEnabled = true)
        {
            path = Path.Combine(path, name + ".xlsx");
            FileInfo file = new(path);
            var groupedResults = AllResults.GroupBy(x => x.AlgorithmName);

            foreach (var group in groupedResults)
            {
                var groupAr = group.ToArray();
                if (!EmissionsEnabled) Services.DeleteEmissions(groupAr);
                SaveManager.SaveTable(file, groupAr, "ID (n)", "Time (Milliseconds)");
            }
        }
    }
}