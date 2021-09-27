using Algorithms.FirstTask;
using System;
using System.Diagnostics;
using System.Linq;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;
using Tester.Meta.Testers;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
           var a = BigTestMatrixAlgorithm((Func<Graph<uint>, Node<uint>, Node<uint>, uint>)GraphShortestPath.AlgortighmFloydWarshall);
            Console.WriteLine(a);
        }
        static bool BigTestMatrixAlgorithm(Func<Graph<uint>, Node<uint>, Node<uint>, uint> function)
		{
            uint[] values = { 1, 2, 3, 4 };
            int[] links = { 0, 1, 1, 2, 2, 3, 3, 0 };
            var graph = Graph<uint>.MakeGraph<uint>(values, links);
            var result = function.Invoke(graph, graph[0], graph[2]);
            return 3 == (double)result;
        }
    }
}
