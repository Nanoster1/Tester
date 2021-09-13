using System;
using System.Collections.Generic;
using System.Linq;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;

namespace Tester.Meta.Algorithms.FirstTask
{
    public class SeventhAlgorithm : IAlgorithm
    {
        public string Name => nameof(SeventhAlgorithm);

        private List<int[]> ParseVector(int[] vector)
        {
            (int, int) GetMinRun(int size)
            {
                int[] indexes = new int[33];
                for(int i = 32; i <= 64; i++)
                {
                    indexes[i-32] = (int)MathF.Floor(size/(float)i);
                }
                var min = indexes.Min();
                return (Array.IndexOf(indexes, min), min);
            }
            List<int[]> list = new();
            var minRun = GetMinRun(vector.Count());
            for(int i = 1; i < minRun.Item2; i++)
            {
                var newVector = vector.Skip(minRun.Item1 * (i-1)).Take(i * minRun.Item1).ToArray();
                list.Add(newVector);
            }
            var lastVector= vector.Skip(minRun.Item1 * (minRun.Item2 - 1)).Take(vector.Length).ToArray();
            list.Add(lastVector);
            return list;
        }
        
        int[] InsertionSort(int[] vector)
        {    
            void Swap(int[] vector, int i, int j)
            {
                int temp = vector[i];
                vector[i] = vector[j];
                vector[j] = temp;
            }   
            int x;
            int j;
            for (int i = 1; i < vector.Length; i++)
            {
                x = vector[i];
                j = i;
            while (j > 0 && vector[j - 1] > x)
            {
                Swap(vector, j, j - 1);
                j -= 1;
            }
                vector[j] = x;
            }
            return vector;
        }
        private int[] SortListVector(List<int[]> vectors)
        {
            if(vectors.Count > 1)
            {
                vectors[0] = InsertionSort(vectors[0]).Concat(InsertionSort(vectors[1])).ToArray();
                vectors.RemoveAt(1);
                SortListVector(vectors);
            }
            return InsertionSort(vectors[0]);
        }
        private int[] TimSort(int[] vector)
        {
            var vectors = new List<int[]>(){vector};
            if(vector.Length > 64)
            {
                vectors = ParseVector(vector);
            }
            return SortListVector(vectors);
        }
        public void TestRun(object[] @params = null)
        {
            TimSort((int[])@params[0]);
        }
    }
}