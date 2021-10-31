using System;
using System.Collections.Generic;
using Algorithms.FirstTask.SecondTask;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var Queue1 = new Algorithms.SecondTask.Queue<object>();
            var text = CommandsManger.ParseText(new string[]{"Queue1: 1,56 2 4 5 1,car 5 1,cat 5;"});
            var list = new List<CommandStruct<object>>()
            {
                new CommandStruct<object>(Queue1, nameof(Queue1))
            };
            var results = CommandsManger.ActivateCommands(text, list);
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
