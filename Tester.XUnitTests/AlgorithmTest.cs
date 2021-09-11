using System;
using System.Collections.Generic;
using System.Reflection;
using Tester.Meta.Algorithms.FirstTask;
using Tester.Meta.Interfaces;
using Tester.Meta.Servis;
using Tester.Meta.Testers;
using Xunit;

namespace Tester.XUnitTests
{
    public class AlgorithmTest
    {
        [Theory]
        [MemberData(nameof(AlgorithmData))]
        public void AlgorithmsTest(IAlgorithm algorithm) 
        {
            var path = Path.Combine(FileWorker.AlgorithmFolder.FullName,$"text{algorithm.ToString()}.csv");
            var list = new List<string>();
			for (int i = 1; i <= 2000; i++)
			{
                TimeSpan time = TimeSpan.Zero;
				for (int y = 0; y <= 5; y++)
				{
                    var tester = new TimeTester();
                    tester.Test(algorithm);
                    time += tester.Result;
                }
                list.Add($"{time / 5};");
            }
            File.WriteAllLines(path, list);
        }
        public static IEnumerable<object[]> AlgorithmData()
        {
            yield return new object[] {new FirstAlgorithm()};
            yield return new object[] {new SecondAlgorithm()};
            yield return new object[] {new ThirdAlgorithm()};
        }
    }
}
