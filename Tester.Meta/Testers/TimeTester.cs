using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Drawing.Chart.Style;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;

namespace Tester.Meta.Testers
{
    public class TimeTester : ITester<double>
    {
        public TimeTester()
        {
            LastResult = new();
            AllResults = new List<TestResult<double>>();
        }

        public TestResult<double> LastResult { get; protected set; }
        public IList<TestResult<double>> AllResults { get; protected set; }

        public void Test(Action algorithm, int iterationNumber, string name)
        {
            var time = new Stopwatch();
            var localResults = new double[iterationNumber];
            algorithm.Invoke(); //First "long" start
            for (int i = 0; i < iterationNumber; i++)
            {
                time.Restart();
                algorithm.Invoke();
                time.Stop();
                localResults[i] = time.Elapsed.TotalMilliseconds;
            }
            var resultID = AllResults.Count(x => x.AlgorithmName == name) + 1;
            var generalResult = localResults.Average();
            TestResult<double> testResult = new(resultID, name, generalResult, localResults);
            LastResult = testResult;
            lock (AllResults) 
            {
                AllResults.Add(testResult); 
            }
        }

        private double[] DeleteEmissions(double[] localResults)
        {
            var q1Index = (localResults.Length + 1) / 4d - 1;
            var q3Index = 3 * (localResults.Length + 1) / 4d - 1;
            var q1 = 
                localResults[(int) q1Index] + 
                (q1Index - (int) q1Index) * (localResults[(int) q1Index] - localResults[((int) q1Index) + 1]);
            var q3 = localResults[(int) q3Index] + 
                 (q3Index - (int) q3Index) * (localResults[(int) q3Index] - localResults[((int) q3Index) + 1]);
            var mp = q3 - q1;
            var lowerBorder = q1 - 1.5 * mp;
            var upperBorder = q3 + 1.5 * mp;
            var newLocalResults = localResults.ToList();
            for (int i = 0; i < localResults.Length; i++)
            {
                if (localResults[i] <= lowerBorder || localResults[i] >= upperBorder)
                    newLocalResults.Remove(localResults[i]);
            }

            return newLocalResults.ToArray();
        }
        private TestResult<double>[] DeleteEmissions(TestResult<double>[] localResults)
        {
            var q1Index = (localResults.Length + 1) / 4d - 1;
            var q3Index = 3 * (localResults.Length + 1) / 4d - 1;
            var q1 = 
                localResults[(int) q1Index].Result + 
                (q1Index - (int) q1Index) * (localResults[(int) q1Index].Result - localResults[((int) q1Index) + 1].Result);
            var q3 = localResults[(int) q3Index].Result + 
                     (q3Index - (int) q3Index) * (localResults[(int) q3Index].Result - localResults[((int) q3Index) + 1].Result);
            var mp = q3 - q1;
            var lowerBorder = q1 - 1.5 * mp;
            var upperBorder = q3 + 1.5 * mp;
            var newLocalResults = localResults.ToList();
            for (int i = 0; i < localResults.Length; i++)
            {
                if (localResults[i].Result <= lowerBorder || localResults[i].Result >= upperBorder)
                    newLocalResults.Remove(localResults[i]);
            }

            return newLocalResults.ToArray();
        }
        
        public void SaveAsExcel(string path, string name)
        {
            path = Path.Combine(path, name + ".xlsx");
            FileInfo file = new(path);
            var groupedResults = AllResults.GroupBy(x => x.AlgorithmName);

            foreach (var group in groupedResults)
            {
                SaveManager.SaveTable(file, DeleteEmissions(group.ToArray()), "ID (n)", "Time (Milliseconds)");
            }
        }
    }
}