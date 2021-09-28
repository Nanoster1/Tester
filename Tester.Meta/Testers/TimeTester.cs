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
            algorithm.Invoke(); //First "long" start
            var localResults = new double[iterationNumber];
            
            for (int i = 0; i < iterationNumber; i++)
            {
                time.Restart();
                algorithm.Invoke();
                time.Stop();
                localResults[i] = time.Elapsed.TotalMilliseconds;
            }

            var minResult = localResults.Min();
            localResults = localResults
                .Select(localResult => localResult > minResult * 2 ? minResult: localResult)
                .ToArray();

            var resultID = AllResults.Count(x => x.AlgorithmName == name) + 1;
            var generalResult = localResults.Average();

            TestResult<double> testResult = new(resultID, name, generalResult , localResults);
            LastResult = testResult;
            
            lock (AllResults) 
            {
                AllResults.Add(testResult); 
            }
        }


    }
}