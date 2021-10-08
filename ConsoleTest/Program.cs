using Algorithms.FirstTask;
using System;
using System.Diagnostics;
using System.Linq;
using Algorithms.FirstTask.FirstTask;
using Tester.DataTypes;
using Tester.Meta.Interfaces;
using Tester.Meta.Testers;
using Tester.Meta.Models;
using SlavaAlgorithms;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var tester = new TimeTester();
            var tester1 = new MemoryTester();
            var num = Fibonachi.LazyAlg(2);

            for (int i = 1; i < 2000; i++)
			{
                tester.Test(() => Fibonachi.LazyAlg(i), 5, nameof(Fibonachi.LazyAlg));
                tester1.Test(() => Fibonachi.LazyAlg(i), 5, nameof(Fibonachi.LazyAlg));
            }
            tester.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nameof(TimeTester));
            tester.AllResults.Clear();
            tester1.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nameof(MemoryTester));
            tester1.AllResults.Clear();
        }
    }
}
