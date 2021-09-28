using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Drawing.Chart.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tester.Meta.Models;

namespace Tester.Meta.Interfaces
{
    public interface ITester<TResult>
    {
        public void Test(Action algorithm, int iterationNumber, string name);
        public TestResult<TResult> LastResult { get; }
        public IList<TestResult<TResult>> AllResults { get; }

        public void SaveAsExcel(string path, string name);
    }
}