using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Tester.Meta.Interfaces;
using Tester.Meta.Testers;
using Xunit;
using System.Linq;
using Tester.Meta.Models;
using Tester.Meta.Algorithms.FirstTask;
using Algorithms.FirstTask;
using static Algorithms.FirstTask.EighthAlgorithm;

namespace Tester.XUnitTests
{
    public class AlgorithmTest
    {
        /*[Theory]
        [MemberData(nameof(AlgorithmData))]
        public void AlgorithmsTest(IAlgorithm algorithm) 
        {
            ITester<double> tester = new TimeTester();
            *//* var enumerable = Enumerable.Range(1, 2000);
             enumerable.AsParallel()
                 .ForAll(x => tester.Test(algorithm, 5, new object[] { Vector.RandomGenerate(x) }));*//*
            for (int i = 1; i <= 2000; i++)
            {
                tester.Test(algorithm, 5, new object[] { Vector.RandomGenerate(i).ToArray() });
                if (tester is ISavable savable) savable.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            }
            
        }
        
        public static IEnumerable<object[]> AlgorithmData()
        {
            yield return new object[] { new FirstAlgorithm() };
            yield return new object[] { new SecondAlgorithm() };
            yield return new object[] { new ThirdAlgorithm() };
            yield return new object[] { new FourthAlgorithm() };
            yield return new object[] { new FifthAlgorithm() };
            yield return new object[] { new SixthAlgorithm() };
            yield return new object[] { new SeventhAlgorithm() };
        }*/
        [Fact]
        public void TestPowAlgorithms()
		{
            var algorithm = new EighthAlgorithm();
            var tester = new TimeTester();
            var random = 10.2;
			for (int i = 1; i <= 5; i++)
			{
                tester.Test(algorithm, 5, new object[] { random, i, Methods.Quick});
			}
            tester.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
		}
    }
}
