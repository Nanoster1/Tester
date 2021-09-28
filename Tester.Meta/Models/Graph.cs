using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Meta.Models
{
	public class Graph<T> where T : struct, IComparable<T> 
	{
		private readonly Node<T>[] nodes;
		public Graph(int nodesCount)
		{
			nodes = Enumerable.Range(0, nodesCount).Select(z => new Node<T>(z)).ToArray();
		}
		public IEnumerable<Node<T>> Nodes
		{
			get
			{
				foreach (var node in nodes)
					yield return node;
			}
		}
		public void Connect(int index1, int index2,T value)
		{
			Node<T>.Connect(nodes[index1], nodes[index2],value, this);
		}
		public void Delete(Edge<T> edge)
		{
			Node<T>.Disconnect(edge);
		}
		public IEnumerable<Edge<T>> Edges
		{
			get
			{
				return nodes.SelectMany(z => z.IncidentEdges).Distinct();
			}
		}

		public int Length { get { return nodes.Length; } }
		public Node<T> this[int index] { get { return nodes[index]; } }
		public static Graph<T> MakeGraph<T>(T[] value,int[] incidentNodes) where T: struct, IComparable<T>
		{
			var graph = new Graph<T>(incidentNodes.Max() + 1);
			for (int i = 0; i < incidentNodes.Length - 1; i += 2)
				graph.Connect(incidentNodes[i], incidentNodes[i + 1],value[i/2]);
			return graph;
		}
		public static uint[,] GetLinkTable(Graph<uint> graph)
		{
			var length = graph.Length;
			uint[,] result = new uint[length,length];

			for (int j = 0; j < length; j++)
			{
				for (int i = 0; i < length; i++)
				{
					if (i == j)
						result[j,i] = 0;
					else
					{
						var res = graph[j].GetValueLinkNode(graph[i]);
						if (!res.HasValue)
							result[j, i] = uint.MaxValue/2;
						else
							result[j, i] = res.Value;
					}
				}
			}
			return result;
		}
		public static Graph<uint> GetRandomGraph(int size)
		{
			var random = new Random();
			var values = new uint[random.Next(1,size)];
			for (int i = 0; i < values.Length; i++)
			{
				values[i] = (uint)random.Next(1, 100);
			}
			var indexs = new int[values.Length * 2];
			int lastIndex = 0;
			for (int i = 0; i < indexs.Length; i++)
			{
				int index;
				do
					index = random.Next(0, size - 1);
				while (lastIndex == index);
				lastIndex = index;
				indexs[i] = index;
			}
			return MakeGraph(values, indexs);
		}
	}
	public class Node<T> where T : struct,IComparable<T>
	{
		private readonly List<Edge<T>> edges = new List<Edge<T>>();
		public Node(int id)
		{
			Number = id;
		}
		public int Number { get; }
		public IEnumerable<Node<T>> IncidentNodes
		{
			get
			{
				return edges.Select(x => x.OtherNode(this));
			}
		}
		public IEnumerable<Edge<T>> IncidentEdges
		{
			get
			{
				foreach (var edge in edges) yield return edge;
			}
		}
		public static Edge<T> Connect(Node<T> node1, Node<T> node2,T value, Graph<T> graph)
		{
			if (!graph.Nodes.Contains(node1) || !graph.Nodes.Contains(node2)) throw new ArgumentException();
			var edge = new Edge<T>(node1, node2,value);
			node1.edges.Add(edge);
			node2.edges.Add(edge);
			return edge;
		}
		public static void Disconnect(Edge<T> edge)
		{
			edge.From.edges.Remove(edge);
			edge.To.edges.Remove(edge);
		}
		public T? GetValueLinkNode(Node<T> node)
		{
			var edge = IncidentEdges.Where(x => x.IsIncident(node));
			if (edge.Count() > 0)
				return (T?)edge.First().Value;
			else
				return null;
		}
		public static bool operator ==(Node<T> node1, Node<T> node2)
		{
			return node1.Number == node2.Number;
		}
		public static bool operator !=(Node<T> node1, Node<T> node2)
		{
			return node1.Number != node2.Number;
		}
	}
	public class Edge<T> where T: struct, IComparable<T>
	{
		public readonly Node<T> From;
		public readonly Node<T> To;
		public readonly T Value;
		public Edge(Node<T> first, Node<T> second,T value)
		{
			From = first;
			To = second;
			Value = value;
		}
		public bool IsIncident(Node<T> node)
		{
			return From == node || To == node;
		}
		public Node<T> OtherNode(Node<T> node)
		{
			if (IsIncident(node))
				if (From == node)
					return To;
				else
					return From;
			else
				throw new AggregateException();

		}
	}
}
