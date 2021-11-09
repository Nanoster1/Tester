using Algorithms.FirstTask.ThirtTask;
using StructsConsole;
using System;
using System.IO;
using System.Linq;
using System.Text;
using Tester.Meta.Interfaces;
using Tester.Meta.Testers;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			LinkedList<IComparable> list = new LinkedList<IComparable>(1, 1);
			list.AddInEnd(1);
			list.AddInEnd(2);
			list.AddInEnd(3);
			list.Remove(1);
			Console.WriteLine(list.ToString());
		}
		
		public static string GetRandomCommnad(int count)
		{
			var rnd = new Random();
			StringBuilder @string = new();
			for (int i = 0; i < count; i++)
			{
				var value = rnd.Next(1, 6);
				if (value == 1)
					@string.Append($"{value},{rnd.Next(1, 100)}");
				else
					@string.Append(value);

			}
			return @string.ToString();
		}
	}
}
