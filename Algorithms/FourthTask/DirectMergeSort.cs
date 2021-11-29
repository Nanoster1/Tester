using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Primitives;

namespace Algorithms.FirstTask.FourthTask
{
    public static class DirectMergeSort
    {
        private static void Display(string changes) => Console.WriteLine(changes);

        public static void Sort<T>(IEnumerable<T> enumerable, Func<T, IComparable> selector)
        {
            T[] array;
            if (enumerable is T[] arr) array = arr;
            else if (enumerable is null) throw new ArgumentNullException();
            else array = enumerable.ToArray();

            var m = 1;
            while (m < array.Length)
            {
                var j = 0;
                Display($"Элементы: {string.Join(", ", array)}");
                Display($"Разбиваем массив:\n{DisplaySubArrays(array, m)}");
                while (j + m < array.Length)
                {
                    Merge(array, j, m, m, selector);
                    j += 2 * m;
                }
                Display("Увеличиваем кол-во элементов для слияния в 2 раза");
                m += m;
            }
            Display($"Финальный массив: {string.Join(", ", array)}");
        }

        private static void Merge<T>(T[] array, int j, int r, int m, Func<T, IComparable> selector)
        {
            if (j + r < array.Length)
            {
                if (m == 1)
                {
                    Display($"Сравниваем {array[j]} и {array[j + r]}");
                    if (selector(array[j]).CompareTo(selector(array[j + r])) == 1)
                    {
                        (array[j], array[j + r]) = (array[j + r], array[j]);
                    }
                }
                else
                {
                    m /= 2;
                    Display($"Сравниваем {array[j]} и {array[j + r]}");
                    Merge<T>(array, j, r , m, selector);
                    if (m + j + r < array.Length)
                    {
                        Display($"Сравниваем {array[j]} и {array[j + r]}");
                        Merge<T>(array, j + m, r, m, selector);
                    }
                    Display($"Сравниваем {array[j]} и {array[j + r]}");
                    Merge<T>(array, j + m, r - m, m, selector);
                }
            }
        }

        private static string DisplaySubArrays<T>(T[] array, int m)
        {
            List<T> subArr1 = new();
            List<T> subArr2 = new();
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (counter < m) subArr1.Add(array[i]);
                else if (counter < 2 * m) subArr2.Add(array[i]);
                if (counter + 1 >= 2 * m) counter = -1;
                counter++;
            }
            var @string = new StringBuilder();
            counter = 1;
            foreach (var element in subArr1)
            {
                if (counter == m)
                {
                    @string.Append(element + " | ");
                    counter = 0;
                }
                else @string.Append(element + ", ");

                counter++;
            }
            @string.Remove(@string.Length - 2, 1);
            @string.AppendLine();
            counter = 1;
            foreach (var element in subArr2)
            {
                if (counter == m)
                {
                    @string.Append(element + " | ");
                    counter = 0;
                }
                else @string.Append(element + ", ");

                counter++;
            }

            return @string.ToString().Trim(new []{',', ' ', '|'});
        }
    }
}