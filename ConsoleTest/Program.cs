using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Algorithms.FirstTask;
using Algorithms.FirstTask.FirstTask;
//using Tester.Meta.Interfaces;
//using Tester.Meta.Testers;
//using Tester.Meta.Models;

namespace ConsoleTest
{
    class Program
    {
        //static void Relocate(Stack<byte> start, Stack<byte> temp, Stack<byte>end, int elements)
        //{
        //    if (elements == 0) return;
        //    Relocate(start, end, temp,elements - 1);
        //    end.Push(start.Pop());
        //    Collect(temp, start, end, elements - 1);
        //}

        //static void Collect(Stack<byte> start, Stack<byte> temp, Stack<byte>end, int elements)
        //{
        //    if (elements == 0) return;
        //    Relocate(start, end, temp,elements - 1);
        //    end.Push(start.Pop());
        //    Collect(temp, start, end, elements - 1);
        //}

        static void Main(string[] args)
        {
            Task3 task = new Task3(Console.ReadLine());
            string[] merge = MergeSort.Sort(task.Text);

            Console.WriteLine("Merge");
            foreach (var i in merge)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("_______________________________________");
            Console.WriteLine("Shaker");
            string[] shaker = ShakerSort.Sort(task.Text);
            foreach (var i in shaker)
            {
                Console.WriteLine(i);
            }
            var dict = Task3.Count(merge);
            foreach (KeyValuePair<string, int> keyValue in dict)
            {
                Console.WriteLine($"{keyValue.Key}: {keyValue.Value}");
            }
            //    var start = new Stack<byte>(Enumerable.Range(0, 4).Select(x => (byte)x));
            //    var temp = new Stack<byte>();
            //    var end = new Stack<byte>();
            //    Relocate(start, temp, end, 4);
            //    foreach (var i in end)
            //    {
            //        Console.Write(i);
            //    }
        }
    }
}
