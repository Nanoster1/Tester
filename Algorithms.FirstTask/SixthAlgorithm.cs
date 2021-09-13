using System;
using System.Linq;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;

namespace Tester.Meta.Algorithms.FirstTask
{
    public class SixthAlgorithm : IAlgorithm
    {
        public string Name => nameof(SixthAlgorithm);

        public int[] QuickSort(int[] vector)
        {
            if (vector.Count() > 1)
            {
                var randomNum = new Random().Next(0, vector.Length);
                var lowNum = vector.Where(x => x < vector[randomNum]).ToArray();
                var normalNum = vector.Where(x => x == vector[randomNum]).ToArray();
                var bigNum = vector.Where(x => x > vector[randomNum]).ToArray();

                vector = QuickSort(lowNum).Concat(normalNum).Concat(QuickSort(bigNum)).ToArray();
            }
            return vector;
        }
        public void TestRun(object[] @params = null)
        {
            QuickSort((int[])@params[0]);
        }
    }
}
