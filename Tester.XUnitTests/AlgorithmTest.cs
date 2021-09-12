using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Tester.Meta.Algorithms.FirstTask;
using Tester.Meta.Interfaces;
using Tester.Meta.Testers;
using Xunit;
using System.Linq;
using Tester.Meta.Models;

namespace Tester.XUnitTests
{
    public class AlgorithmTest
    {
        [Theory]
        [MemberData(nameof(AlgorithmData))]
        public void AlgorithmsTest(IAlgorithm algorithm) 
        {
            var tester = new TimeTester();
            /* var enumerable = Enumerable.Range(1, 2000);
             enumerable.AsParallel()
                 .ForAll(x => tester.Test(algorithm, 5, new object[] { Vector.RandomGenerate(x) }));*/
            for (int i = 0; i < 2000; i++)
            {
                tester.Test(algorithm, 5, new object[] { Vector.RandomGenerate(i) });
            }
            tester.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }
        public static IEnumerable<object[]> AlgorithmData()
        {
            yield return new object[] {new FirstAlgorithm()};
            yield return new object[] {new SecondAlgorithm()};
            yield return new object[] {new ThirdAlgorithm()};
        }
    }
}
