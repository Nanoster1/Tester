using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;

namespace Tester.Meta.Algorithms.FirstTask
{
    public class SixthAlgorithm : IAlgorithm
    {
        public string Name => throw new NotImplementedException();

        public void Sort(Vector vector)
        {

        }
        private int Partition(Vector vector, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (vector[i] < vector[maxIndex])
                {
                    pivot++;
                    var t = vector[pivot];
                    vector[pivot] = vector[i];
                    vector[i] = t;
                }
            }

            pivot++;
            var temp = vector[pivot];
            vector[pivot] = vector[maxIndex];
            vector[maxIndex] = temp;
            return pivot;
        }

        private void QuickSort(Vector vector, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex) return;
            var pivotIndex = Partition(vector, minIndex, maxIndex);
            QuickSort(vector, minIndex, pivotIndex - 1);
            QuickSort(vector, pivotIndex + 1, maxIndex);
        }

        public void QuickSort(Vector vector)
        {
            QuickSort(vector, 0, vector.Count - 1);
        }

        public void TestRun(object[] @params = null)
        {
            QuickSort(@params[0] as Vector);
        }
    }
}
