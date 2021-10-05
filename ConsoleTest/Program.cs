using Algorithms.FirstTask;
using Algorithms.FirstTask.FirstTask;
using Microsoft.FSharp.Collections;
using SlavaAlgorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Tester.DataTypes;
using Tester.Meta.Interfaces;
using Tester.Meta.Testers;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var tester = new MemoryTester();
            var tester1 = new TimeTester();
            List<int> generateRandomArray(int num)
			{
                int i = 0;
                var @string = new List<int>();
                var random = new Random();
				for (i = 1; i < num; i++)
				{
                    @string.Add(i);                   
				}
                return @string;
			}
            for (int i = 1; i <= 11; i++)
            {
                FSharpList<int> lst = ListModule.OfSeq(generateRandomArray(i));
                tester.Test(() => Permutations.FactorialAlg<int>(lst), 3, nameof(Permutations.FactorialAlg));
                tester1.Test(() => Permutations.FactorialAlg<int>(lst), 3, nameof(Permutations.FactorialAlg));
            }
            tester1.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TimeTester");
            tester.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MemoryTester");
        }
    }
}
