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
            var generalResult = CalculateAverage(localResults.OrderBy(x => x).ToArray());
            TestResult<double> testResult = new(resultID, name, generalResult, localResults);
            LastResult = testResult;
            lock (AllResults) 
            {
                AllResults.Add(testResult); 
            }
        }

        private double CalculateAverage(double[] localResults)
        {
            var q1 = Percentile(localResults, 1);
            var q2 = Percentile(localResults, 2);
            for (int i = 0; i < localResults.Length; i++)
            {
                if (localResults[i] < q1)
                    localResults[i] = q1;
                else if (localResults[i] > q2)
                    localResults[i] = q2;
            }
            
            return localResults.Average();
        }
        public double Percentile(double[] sequence, double num)
        {
            int N = sequence.Length;
            double n = (N + 1) * num / 4;
            if (n == 1d) return sequence[0];
            else if (n == N) return sequence[N - 1];
            else
            {
                int k = (int)n;
                double d = n - k;
                return sequence[k - 1] + d * (sequence[k] - sequence[k - 1]);
            }
        }
        public void SaveAsExcel(string path, string name)
        {
            path = Path.Combine(path, name + ".xlsx");
            FileInfo file = new(path);
            var groupedResults = AllResults.GroupBy(x => x.AlgorithmName);

            foreach (var group in groupedResults)
            {
                SaveManager.SaveTable(file, group.ToArray(), "ID (n)", "Time (Milliseconds)");
            }
        }
    }
}