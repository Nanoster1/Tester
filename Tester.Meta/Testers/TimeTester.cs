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
    public class TimeTester : Tester<TimeSpan>, ISavableTester
    {
        public TimeTester()
        {
            LastResult = new();
            AllResults = new();
        }
        public override TestResult<TimeSpan> LastResult { get; protected set; }
        public override List<TestResult<TimeSpan>> AllResults { get; protected set; }

        public override void Test(IAlgorithm algorithm, int iterationNumber, object[] algParams)
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
                TestResult<TimeSpan> testResult = new(AllResults.Count + 1, result / iterationNumber, algorithm.Name);
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