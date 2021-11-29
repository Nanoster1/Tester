using Algorithms.FirstTask.ThirtTask;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Algorithms.FirstTask.FourthTask;
using OfficeOpenXml;
using Tester.Meta.Interfaces;
using Tester.Meta.Testers;

namespace ConsoleApp1
{
	class Program
	{
		static void Main()
		{
			/*var args = Environment.GetCommandLineArgs();
			var duration = double.Parse(args.First(x => x.Contains("dur:")));
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			using ExcelPackage package = new();*/
			var b =  new int[] {2, 5, 6, 1, 2, 0, -4, 234};
			b = b.GetPart(2, 1).ToArray();
			Console.WriteLine(string.Join(", ", b));
		}
		
		/*public static void SaveTable<TResult>(FileInfo file, TestResult<TResult>[] results, string title1, string title2,
			bool isGraphic = true)
		{
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            
			using ExcelPackage package = new(file);
			string name = results[0].AlgorithmName;
			var ws = package.Workbook.Worksheets
				.FirstOrDefault(ws => ws.Name == name);

			if (ws == null) ws = package.Workbook.Worksheets.Add(name);
			else
			{
				ws.Cells.Clear();
				ws.Drawings.Clear();
			}

			ws.Cells[1, 1].Value = title1;
			ws.Cells[1, 2].Value = title2;

			for (int i = 2; i < results.Length + 2; i++)
			{
				ws.Cells[i, 1].Value = results[i - 2].ID;
				ws.Cells[i, 2].Value = results[i - 2].Result;
			}

			ws.Cells[ws.Dimension.Address].AutoFitColumns();
			/*var table = ws.PivotTables.Add(dataRange, dataRange, results[0].AlgorithmName);
			var field = table.RowFields.Add(table.Fields[""]);#1#
			if (isGraphic)
			{
				var rangeX = ws.Cells[$"A2:A{results.Length + 1}"];
				var rangeY = ws.Cells[$"B2:B{results.Length + 1}"];
				AddChart(ws, rangeX, rangeY, name, title1, title2);
			}
			package.Save();
		}*/
	}
}
