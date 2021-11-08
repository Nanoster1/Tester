using Algorithms.FirstTask.ThirtTask;
using System;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			var path = Environment.CurrentDirectory + "\\input.txt";
			if (File.Exists(path))
			{
				using StreamReader stream = new StreamReader(path);
				var text = stream.ReadToEnd();
				var stack = text.GetCommand();
			}
			else
			{
				Console.WriteLine("Такого пути нету");
			}	
		}
	}
}
