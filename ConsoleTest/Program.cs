using System;
using Algorithms.SecondTask;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<dynamic> stack = new();
            stack.Enqueue(1);
            Console.WriteLine(stack);
            stack.Enqueue(2);
            Console.WriteLine(stack);
            stack.Dequeue();
            Console.WriteLine(stack);
            stack.Dequeue();
            Console.WriteLine(stack.IsEmpty);
        }
    }
}
