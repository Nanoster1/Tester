using Algorithms.FirstTask.ThirtTask;
using System;


namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			//var Queue1 = new Algorithms.SecondTask.Queue<string>();
			//var text = CommandsManger.Instance.ParseText(new string[]{"Queue1: 4 5 1,car 5 1,cat 5; Queue1: 1,cat 5"});
			//ICommandStruct<object> element = new CommandStruct<string>(Queue1, nameof(Queue1));
			//CommandsManger.Instance.Variables.Add(element.Name, element);
			//var results = CommandsManger.Instance.ActivateCommands(text);
			//foreach (var result in results)
			//{
			//    Console.WriteLine(result);
			//}
			QueueOfEblan<int> queue = new();
			queue.Enqueue(1);
			queue.Enqueue(2);
			queue.Enqueue(3);
			foreach (var item in queue)
			{
				Console.WriteLine(item.ToString());
			}
		}
	}
}
