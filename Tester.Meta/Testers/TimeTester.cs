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
            var result = TimeSpan.Zero;
            var localResults = new double[iterationNumber];
            algorithm.Invoke(); //First "long" start
            for (int i = 0; i < iterationNumber; i++)
            {
                time.Restart();
                algorithm.Invoke();
                time.Stop();
                result += time.Elapsed;
                localResults[i] = time.Elapsed.TotalMilliseconds;
            }
            var resultID = AllResults.Count(x => x.AlgorithmName == name) + 1;
            var generalResult = (result / iterationNumber).TotalMilliseconds;
            TestResult<double> testResult = new(resultID, generalResult , localResults, name);
            LastResult = testResult;
            lock (AllResults) 
            {
                AllResults.Add(testResult); 
            }
        }
        
        public void SaveAsExcel(string path, string name)
        {
            path = Path.Combine(path, name + ".xlsx");
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using ExcelPackage package = new(new FileInfo(path));

            var groupedResults = AllResults.GroupBy(x => x.AlgorithmName);

            foreach (var group in groupedResults)
            {
                var results = group.ToArray();

                var ws = package.Workbook.Worksheets.FirstOrDefault(ws => ws.Name == results[0].AlgorithmName);

                if (ws == null)
                {
                    ws = package.Workbook.Worksheets.Add(results[0].AlgorithmName);
                }
                else { ws.Cells.Clear(); ws.Drawings.Clear(); }

                ws.Cells[1, 1].Value = "ID";
                ws.Cells[1, 2].Value = "Time";

                for (int i = 2; i <= results.Length + 1; i++)
                {
                    ws.Cells[i, 1].Value = i - 1;
                    ws.Cells[i, 2].Value = results[i - 2].Result;
                }

                var range1 = ws.Cells[$"A1, B{results.Length + 1}"];

                var chart = ws.Drawings.AddChart("FindingsChart", eChartType.XYScatterLinesNoMarkers);

                chart.Title.Text = results[0].AlgorithmName;
                chart.SetPosition(7, 0, 5, 0);
                chart.SetSize(800, 400);

                var actualCount = results.Length;
                if (actualCount < 3) actualCount = 3;
                var serie = chart
                    .Series
                    .Add(ws.Cells[$"B2:B{actualCount + 1}"], ws.Cells[$"A2:A{actualCount + 1}"]);

                chart.XAxis.AddTitle("Time");
                chart.YAxis.AddTitle("Complexity of input data");
                chart.StyleManager.SetChartStyle(ePresetChartStyle.ScatterChartStyle6);
    
                package.Save();
            }
        }
    }
}