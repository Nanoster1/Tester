using Algorithms.FirstTask;
using System;
using System.Collections.Generic;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;
using Tester.Meta.Testers;
using Xunit;
namespace Tester.XUnitTests
{
	public class GraphAlgoritmTests
	{
		[Theory]
		[MemberData(nameof(GetGraphAlgs))]
		public void TestGraphAlgorithm(Func<Graph<uint>, Node<uint>, Node<uint>, uint> graphFunc)
		{
			uint[] values = { 1, 2, 3, 4 };
			int[] links = { 0, 1, 1, 2, 2, 3, 3, 0 };
			var graph = Graph<uint>.MakeGraph<uint>(values, links);
			var result = graphFunc.Invoke(graph, graph[0], graph[2]);
			Assert.Equal(3, (double)result);
		}
		public static IEnumerable<object[]> GetGraphAlgs()
		{
			yield return new object[] { (Func<Graph<uint>, Node<uint>, Node<uint>, uint>)GraphShortestPath.AlgortighmFloydWarshall };
		}
		[Fact]
		public void GraphShortedPathAlgTest()
		{
			BigTestGraphAlgorithm((x, y, z) => GraphShortestPath.AlgortighmFloydWarshall(x, y, z), nameof(GraphShortestPath.AlgortighmFloydWarshall), 1);
		}
		private static void BigTestGraphAlgorithm(Func<Graph<uint>, Node<uint>, Node<uint>, object> function, string name, int interationCount)
		{
			ITester<long> tester = new MemoryTester();
			ITester<double> tester2 = new TimeTester();
			for (int i = 0; i < 100; i++)
			{
				var graph = Graph<uint>.GetRandomGraph(i);

				tester.Test(() => function.Invoke(graph, graph[0], graph[1]), interationCount, name);
				tester2.Test(() => function.Invoke(graph, graph[0], graph[1]), interationCount, name);
			}
			VectorAlgorithmTests.SaveResult(tester, tester2);
		}
	}
}
