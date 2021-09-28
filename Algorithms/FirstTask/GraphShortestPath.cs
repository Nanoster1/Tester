using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester.Meta.Models;

namespace Algorithms.FirstTask
{
	public static class GraphShortestPath
	{
		public static uint AlgortighmFloydWarshall(Graph<uint> graph, Node<uint> node1, Node<uint> node2)
		{
            var matrix = Graph<uint>.GetLinkTable(graph);
            var size = matrix.Length / matrix.GetLength(0);
            var points = new int[size, size];
            for (int k = 0; k < size; ++k)            
                for (int i = 0; i < size; ++i)
                    for (int j = 0; j < size; ++j)
                        if(matrix[i, j] > (matrix[i, k] + matrix[k, j]))
						{
                            matrix[i, j] = matrix[i, k] + matrix[k, j];
                            points[i, j] = k;
						}               
            var num1 = node1.Number;
            var num2 = node2.Number;
            return matrix[num1, num2];
        }
	}
}
