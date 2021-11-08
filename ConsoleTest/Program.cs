using Algorithms.FirstTask.ThirtTask;
using System;
using System.IO;
using System.Linq;
using StructsConsole;
using Tester.Meta.Interfaces;
using Tester.Meta.Testers;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(ArithmeticManager.Instance.Calculate("2+2"));
		}
		
		public static string GetRandomCommnad(int count)
		{
			var rnd = new Random();
			System.Text.StringBuilder @string = new();
			for (int i = 0; i < count; i++)
			{
				var value = rnd.Next(1, 6);
				if (value == 1)
					@string.Append($"{value},{rnd.Next()}");
				else
					@string.Append(value);

			}
			return @string.ToString();
		}
	}
}
