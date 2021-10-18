using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Tester.Meta.Interfaces;
using Tester.Meta.Testers;
using Tester.Meta.Models;
using SlavaAlgorithms;

namespace ConsoleTest
{
    class Program
    {
        static void Relocate(Stack<byte> start, Stack<byte> temp, Stack<byte>end, int elements)
        {
            if (elements == 0) return;
            Relocate(start, end, temp,elements - 1);
            end.Push(start.Pop());
            Collect(temp, start, end, elements - 1);
        }

        static void Collect(Stack<byte> start, Stack<byte> temp, Stack<byte>end, int elements)
        {
            if (elements == 0) return;
            Relocate(start, end, temp,elements - 1);
            end.Push(start.Pop());
            Collect(temp, start, end, elements - 1);
        }
        
        static void Main(string[] args)
        {
            var start = new Stack<byte>(Enumerable.Range(0, 4).Select(x => (byte)x));
            var temp = new Stack<byte>();
            var end = new Stack<byte>();
            Relocate(start, temp, end, 4);
            foreach (var i in end)
            {
                Console.Write(i);
            }
        }
    }
}
