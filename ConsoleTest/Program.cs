using Algorithms.FirstTask.ThirtTask;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Algorithms.FirstTask.FourthTask;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using Tester.Meta.Interfaces;
using Tester.Meta.Testers;

namespace ConsoleApp1
{
	class Program
	{
		private enum Attribute
		{
			Length, Number, Alphabet
		}

		private static void Main()
		{
			var args = Environment.GetCommandLineArgs();
			var duration = int.Parse(args.FirstOrDefault(x => x.Contains("duration:"))?.Split(':')[1] ?? "0");
			var key = args.FirstOrDefault(x => x.Contains("key:"))?.Split(':')[1];
			var originalPath = args.FirstOrDefault(x => x.Contains("originalPath:"))?.Split(':')[1] ?? Path.Combine(Environment.CurrentDirectory, "test.txt");
			var separator = args.FirstOrDefault(x => x.Contains("separator:"))?.Split(':')[1] ?? ";";
			var attribute = (Attribute)Enum.Parse(typeof(Attribute), args.First(x => x.Contains("attribute:")).Split(':')[1]);
			
			var sorterModel = new DirectMergeSortModel(originalPath, duration, Convert.ToChar(separator), key);

			Func<string, IComparable> selector = attribute switch
			{
				Attribute.Length => x => x.Length,
				Attribute.Alphabet => x => new AlphabetStr(x),
				Attribute.Number => x => Convert.ToInt64(x),
				_ => throw new ArgumentOutOfRangeException()
			};
			sorterModel.Sort(selector);
			Console.ReadKey();
		}
		
		private class AlphabetStr: IComparable
		{
			public string _str;
			public AlphabetStr(string str)
			{
				_str = str;
			}

			public int CompareTo(object? obj)
			{
				if (obj is AlphabetStr str)
				{
					var min = Math.Min(_str.Length, str._str.Length);
					for (var i = 0; i < min; i++)
					{
						if (_str[i] > str._str[i]) return 1;
						else if (_str[i] < str._str[i]) return 0;
					}
				}

				return 0;
			}
		}
	}
}
