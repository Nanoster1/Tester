using Algorithms.FirstTask.ThirtTask;
using System;
using System.IO;
using System.Linq;
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
            for (int i = 1; i < 20000; i++)
            {
                var command = GetRandomCommnad(i);
				tester.Test(()=>command.GetCommand(), 5, "CommandTester");
				tester2.Test(() => command.GetCommand(), 5, "CommandTester");
			}
            tester.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nameof(MemoryTester));
            tester.AllResults.Clear();
            tester2.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nameof(TimeTester));
            tester2.AllResults.Clear();
        }
		
		public static string GetRandomCommnad(int count)
		{
			var rnd = new Random();
			System.Text.StringBuilder @string = new();
			for (int i = 0; i < count; i++)
			{
				var value = rnd.Next(1, 6);
				if (value == 1)
					@string.Append($"{value},{rnd.Next()}");
				else
					@string.Append(value);

			}
			return @string.ToString();
		}
	}
}
