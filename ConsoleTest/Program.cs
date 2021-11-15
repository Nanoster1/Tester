using Algorithms.FirstTask.ThirtTask;
using StructsConsole;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using Tester.Meta.Interfaces;
using Tester.Meta.Testers;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			ITester<long> tester = new MemoryTester();
			ITester<double> tester2 = new TimeTester();
			for (int i = 2; i < 20000; i++)
			{
				var command = GetRandomCommnad(i);
				tester.Test(()=> command.GetCommand2(), 5, nameof(Queue));
				tester2.Test(() => command.GetCommand2(), 5, nameof(Queue));
			}
			tester.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nameof(MemoryTester));
			tester.AllResults.Clear();
			tester2.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nameof(TimeTester));
			tester2.AllResults.Clear();
		}
		
		public static string GetRandomCommnad(int count)
		{
			var rnd = new Random();
			StringBuilder @string = new();
			for (int i = 0; i < count; i++)
			{
				var value = rnd.Next(1, 6);
				if (value == 1)
					@string.Append($"{value},{rnd.Next(1, 100)}");
				else
					@string.Append(value);

			}
			return @string.ToString();
		}
	}
}
