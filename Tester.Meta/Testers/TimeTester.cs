using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Drawing.Chart.Style;

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
            var result = TimeSpan.Zero;
            algorithm.Invoke(); //First "long" start
            for (int i = 0; i < iterationNumber; i++)
            {
                time.Restart();
                algorithm.Invoke();
                time.Stop();
                result += time.Elapsed;
            }
            var resultID = AllResults.Count(x => x.AlgorithmName == name) + 1;
            var generalResult = (result / iterationNumber).TotalMilliseconds;
            TestResult<double> testResult = new(resultID, generalResult , name);
            LastResult = testResult;
            lock (AllResults) 
            {
                AllResults.Add(testResult); 
            }
        }
    }
}