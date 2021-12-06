using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Algorithms.FirstTask;
using Algorithms.FirstTask.FirstTask;
using Tester.Meta.Interfaces;
using Tester.Meta.Testers;

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
            var file = new SortFile(@"C:\Users\Nanoster\Desktop\test.txt", value =>
            {
                Console.WriteLine(value);
            });
            file.SortByFiles(1);
        }
        public static void SaveResult(ITester<long> tester, ITester<double> tester2)
        {
            tester.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nameof(MemoryTester));
            tester.AllResults.Clear();
            tester2.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nameof(TimeTester));
            tester2.AllResults.Clear();
        }
        private static ICollection<string> GetRecursiveMsdSortedArray(ICollection<string> array, int depth)
        {
            if (array.Count > 1)
            {
                var baskets = new Dictionary<char, List<string>>();
                baskets.Add((char)96, new List<string>());
                foreach (var word in array)
                {
                    if (depth < word.Length)
                    {
                        if (baskets.ContainsKey(word[depth]))
                            baskets[word[depth]].Add(word);
                        else
                            baskets.Add(word[depth], new List<string> { word });
                    }
                    else
                    {
                        baskets[(char)96].Add(word);
                    }
                }

                if (baskets[(char)96].Count == array.Count)
                    return array;

                List<string> output = new List<string>();
                for (int i = 96; i <= 122; i++)
                {
                    if (baskets.ContainsKey((char)i))
                    {
                        foreach (string word in GetRecursiveMsdSortedArray(baskets[(char)i], depth + 1))
                            output.Add(word);
                    }
                }

                return output;
            }
            else
            {
                return array;
            }
        }
    }
}
