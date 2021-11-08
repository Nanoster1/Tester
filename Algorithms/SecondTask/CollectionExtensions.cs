using System;
using System.Collections.Generic;

namespace Algorithms.SecondTask
{
    public static class CollectionExtensions
    {
        public static void ApplyOperations<T>(this Stack<T> stack, IEnumerable<Operations> operations, Queue<T> args)
        {
            foreach (var operation in operations)
            {
                T result;
                switch (operation)
                {
                    case (Operations.Add):
                        stack.Push(args.Dequeue());
                        Console.WriteLine("Operation {0}", nameof(stack.Push));
                        break;
                    case (Operations.Remove):
                        result = stack.Pop();
                        Console.WriteLine("Operation {0}, result: {1}", nameof(stack.Pop), result);
                        break;
                    case (Operations.Peek):
                        result = stack.Top;
                        Console.WriteLine("Operation {0}, result: {1}", nameof(stack.Top), result);
                        break;
                    case (Operations.IsEmpty):
                        var res = stack.IsEmpty;
                        Console.WriteLine("Operation {0}, result: {1}", nameof(stack.IsEmpty), res);
                        break;
                    case (Operations.Print):
                        Console.WriteLine(stack);
                        break;
                }
            }
        }
        public static void ApplyOperations<T>(this Queue<T> queue, IEnumerable<Operations> operations, Queue<T> args)
        {
            foreach (var operation in operations)
            {
                T result;
                switch (operation)
                {
                    case (Operations.Add):
                        queue.Enqueue(args.Dequeue());
                        Console.WriteLine("Operation {0}", nameof(queue.Enqueue));
                        break;
                    case (Operations.Remove):
                        result = queue.Dequeue();
                        Console.WriteLine("Operation {0}, result: {1}", nameof(queue.Dequeue), result);
                        break;
                    case (Operations.Peek):
                        result = queue.Peek;
                        Console.WriteLine("Operation {0}, result: {1}", nameof(queue.Peek), result);
                        break;
                    case (Operations.IsEmpty):
                        var res = queue.IsEmpty;
                        Console.WriteLine("Operation {0}, result: {1}", nameof(queue.IsEmpty), res);
                        break;
                    case (Operations.Print):
                        Console.WriteLine(queue);
                        break;
                }
            }
        }
    }
}