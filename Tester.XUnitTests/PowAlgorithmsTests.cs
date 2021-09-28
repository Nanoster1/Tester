using Algorithms.FirstTask;
using System;
using System.Collections.Generic;
using Tester.Meta.Interfaces;
using Tester.Meta.Testers;
using Xunit;

namespace Tester.XUnitTests
{
	public class PowAlgorithmsTests
	{
		[Theory]
		[MemberData(nameof(GetPowAlgs))]
		public void TestPowAlgorithm(Func<double, int, double> sortFunc)
		{
			int rank = 3;
			double num = 1.5;
			var result = sortFunc.Invoke(num, rank);
			Assert.Equal(result, Math.Pow(num, rank));
		}
		public static IEnumerable<object[]> GetPowAlgs()
		{
			yield return new object[] { (Func<double, int, double>)Pow.Cycle };
			yield return new object[] { (Func<double, int, double>)Pow.QuickPow };
			yield return new object[] { (Func<double, int, double>)Pow.QuickPowAlt };
			yield return new object[] { (Func<double, int, double>)Pow.Recursion };
		}
		[Fact]
		public void PowCycleTest()
		{
			BigTestPowAlgorithm(x => Pow.Cycle(10.12, x), nameof(Pow.Cycle), 5);
		}
		[Fact]
		public void QuickPowTest()
		{
			BigTestPowAlgorithm(x => Pow.QuickPow(10.12, x), nameof(Pow.QuickPow), 5);
		}
		[Fact]
		public void PowRecursionTest()
		{
			BigTestPowAlgorithm(x => Pow.Recursion(10.12, x), nameof(Pow.Recursion), 5);
		}
		[Fact]
		public void QuickPowAltTest()
		{
			BigTestPowAlgorithm(x => Pow.QuickPowAlt(10.12, x), nameof(Pow.QuickPowAlt), 5);
		}
		private static void BigTestPowAlgorithm(Func<int, object> function, string name, int interationCount)
		{
			ITester<long> tester = new MemoryTester();
			ITester<double> tester2 = new TimeTester();
			for (int i = 0; i < 2000; i++)
			{
				tester.Test(() => function.Invoke(i), interationCount, name);
				tester2.Test(() => function.Invoke(i), interationCount, name);
			}
			VectorAlgorithmTests.SaveResult(tester, tester2);
		}
	}
}
