﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.FirstTask.ThirtTask
{
	public static class StackExstenstions
	{
		public static StackOfEblan<object> GetCommand(this string command)
		{
			var commands = command.Split(' ').Where( x => x.IsNormalized()).Select( x => x.Trim());
			var stack = new StackOfEblan<object>();

			foreach (var item in commands)
			{
				try
				{
					if (item.Contains("1"))
						stack.Push(GetElement(item, '1'));
					else if (item.Contains("2"))
						stack.Pop();
					else if (item.Contains("3"))
						stack.Top();
					else if (item.Contains("4"))
						stack.IsEmpty();
					else if (item.Contains("5"))
						Console.WriteLine(stack.ToString());
					else
						throw new Exception("Uncorrect command");
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.Message);
				}			
			}
			return stack;
			static object GetElement(string command,char num)
			{
				var answer = command.Split(',');
				if (answer.Length == 2)
					return answer[1];
				else if (answer.Length == 3)
					return answer[1].Concat(answer[2]);
				else
					return null;
			}
		}
		public static string GetRandomCommnad(int count)
		{
			var rnd = new Random();
			StringBuilder @string = new ();
			for (int i = 0; i < count; i++)
			{
				var value = rnd.Next(1, 5);
				if(value == 1)
					@string.Append($"{value},{rnd.Next()}");
				else
					@string.Append(value);

			}
			return @string.ToString();
		}
	}
}
