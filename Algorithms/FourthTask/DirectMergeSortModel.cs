using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Extensions.Primitives;

namespace Algorithms.FirstTask.FourthTask
{
    public class DirectMergeSortModel
    {
        private readonly FileInfo _file;
        private IEnumerable<string> GetLines => File.ReadLines(_file.FullName);
        private int _linesCount;
        private int _duration;
        private int _neededColumn;
        private char _separator;
        public DirectMergeSortModel(string path, int duration, char separator, string key)
        {
            _file = new FileInfo(path);
            _linesCount = GetLines.Count() - 1;
            _duration = duration;
            _separator = separator;
            _neededColumn = key is null ? _neededColumn = 0 : Array.IndexOf(File.ReadLines(path).First().Split(separator), key);
        }
        
        private string ReadLine(int index)
        {
            var lines = File.ReadLines(_file.FullName);
            var counter = 0;
            foreach (var line in lines)
            {
                if (counter == index + 1)
                    return line;
                counter++;
            }

            throw new IndexOutOfRangeException();
        }

        private void SwapLines(int index1, int index2)
        {
            var line1 = ReadLine(index1);
            var line2 = ReadLine(index2);
            var counter = 0;
            var file = new FileInfo(_file.FullName);
            var oldLines = File.ReadLines(_file.FullName);
            var tempPath = Path.Combine(Environment.CurrentDirectory, "temp.txt");
            var tempFile = new FileInfo(tempPath);
            using (var stream = tempFile.OpenWrite())
            {
                foreach (var oldLine in oldLines)
                {
                    if (counter == index1 + 1) stream.Write(Encoding.Default.GetBytes(line2 + "\n"));
                    else if (counter == index2 + 1) stream.Write(Encoding.Default.GetBytes(line1 + "\n"));
                    else stream.Write(Encoding.Default.GetBytes(oldLine + "\n"));
                    counter++;
                }
            }
            File.Replace(tempFile.FullName, _file.FullName, null);
        }
        
        public void Sort(Func<string, IComparable> selector)
        {
            var count = _linesCount;
            
            var m = 1;
            while (m < count)
            {
                var j = 0;
                DisplayArray(GetLines, m, ConsoleColor.Yellow, ConsoleColor.Green, true);
                DisplayMessage("Разбиваем массив:");
                DisplaySubArrays(GetLines, m);
                while (j + m < count)
                {
                    Merge(j, m, m, selector);
                    j += 2 * m;
                }
                DisplayMessage("Увеличиваем кол-во элементов для слияния в 2 раза");
                m += m;
            }
            DisplayMessage($"Финальный массив: {string.Join(", ", GetLines)}");
        }

        private void Merge(int j, int r, int m, Func<string, IComparable> selector)
        {
            var count = _linesCount;
            if (j + r < count)
            {
                if (m == 1)
                {
                    var firstLine = ReadLine(j).Split(_separator)[_neededColumn];
                    var secondLine = ReadLine(j + r).Split(_separator)[_neededColumn];
                    DisplayMessage($"Сравниваем {firstLine} и {secondLine}");
                    if (selector(firstLine).CompareTo(selector(secondLine)) == 1)
                    {
                        SwapLines(j, j + r);
                    }
                }
                else
                {
                    m /= 2;
                    Merge(j, r , m, selector);
                    if (m + j + r < count)
                    {
                        Merge(j + m, r, m, selector);
                    }
                    Merge(j + m, r - m, m, selector);
                }
            }
        }
        
        private void DisplayMessage(string changes)
        {
            Thread.Sleep(_duration);
            Console.WriteLine(changes);
        }

        private void DisplaySubArrays(IEnumerable<string> array, int m)
        {
            Thread.Sleep(_duration);
            List<string> subArr1 = new();
            List<string> subArr2 = new();
            var counter = -1;
            foreach (var element in array)
            {
                if (counter == -1)
                {
                    counter++;
                    continue;
                }
                if (counter < m) subArr1.Add(element);
                else if (counter < 2 * m) subArr2.Add(element);
                if (counter + 1 >= 2 * m) counter = -1;
                counter++;
            }
            DisplayArray(subArr1, m, ConsoleColor.Blue, ConsoleColor.DarkGreen);
            DisplayArray(subArr2, m, ConsoleColor.Blue, ConsoleColor.DarkGreen);
        }

        private void DisplayArray(IEnumerable<string> array, int m, ConsoleColor color1, ConsoleColor color2, bool ignoreFirstLine = false)
        {
            Thread.Sleep(_duration);
            Console.ForegroundColor = ConsoleColor.Black;
            var counter = ignoreFirstLine ? -1 : 0;
            foreach (var element in array)
            {
                if (counter == -1)
                {
                    counter++;
                    continue;
                }
                if (counter < m)
                {
                    Console.BackgroundColor = color1;
                    Console.Write(' ' + element + ' ');
                }
                else if (counter < 2 * m)
                {
                    Console.BackgroundColor = color2;
                    Console.Write(' ' + element + ' ');
                }
                if (counter + 1 >= 2 * m) counter = -1;
                counter++;
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        } 
    }
}