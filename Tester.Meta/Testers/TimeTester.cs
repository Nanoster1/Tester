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

namespace Tester.Meta.Testers
{
    public class TimeTester : ITester<double>, ISavable
    {
        public TimeTester()
        {
            LastResult = new();
            AllResults = new();
        }
        public TestResult<double> LastResult { get; protected set; }
        public List<TestResult<double>> AllResults { get; protected set; }

        public void Test(IAlgorithm algorithm, int iterationNumber, object[] algParams)
        {
            var time = new Stopwatch();
            var result = TimeSpan.Zero;
            for (int i = 0; i < iterationNumber + 1; i++)
            {
                time.Restart();
                algorithm.TestRun(algParams);
                time.Stop();
                result += time.Elapsed;
            }
            lock (AllResults)
            {
                TestResult<double> testResult = new(AllResults.Count + 1, (result / iterationNumber).TotalMilliseconds, algorithm.Name);
                AllResults.Add(testResult);
                LastResult = testResult;
            }
        }
        
        public void Save(string path)
        {
            path = Path.Combine(path, $"TimeTester_{LastResult.AlgorithmName}.csv");
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture);
            configuration.Delimiter = ";";
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, configuration))
            {
                csv.WriteRecords(AllResults);
            }
        }
    }
}