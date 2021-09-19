using System;
using System.Linq;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;

namespace Algorithms.FirstTask
{
    public static class VectorSorts
    {
        public static double[] QuickSort(double[] vector)
        {
            if (vector.Length <= 1) return vector;
            var randomNum = vector[new Random().Next(0, vector.Length)];

            int bigCount = 0;
            int lowCount = 0;
            int equalCount = 0;
            
            foreach(var element in vector)
            {
                if (element > randomNum) 
                    bigCount++;
                else if (element < randomNum) 
                    lowCount++;
                else 
                    equalCount++;
            }

            double[] bigElements = new double[bigCount];
            double[] lowElements = new double[lowCount];
            double[] equalElements = new double[equalCount];

            foreach(var element in vector)
            {
                if (element > randomNum)
                    bigElements[bigCount - 1] = element;
                else if (element < randomNum)
                    lowElements[lowCount - 1] = element;
                else
                    equalElements[equalCount - 1] = element;
            }

            QuickSort(lowElements);
            QuickSort(bigElements);

            for(int i = 0; i < vector.Length; i++)
            {
                if (i < lowElements.Length)
                    vector[i] = lowElements[i];
                else if (i - lowElements.Length < equalElements.Length)
                    vector[i] = equalElements[i - lowElements.Length];
                else
                    vector[i] = bigElements[i - lowElements.Length - equalElements.Length];
            }
            return vector;
        }

        public static double[] BubbleSort(double[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                for (int k = i + 1; k < vector.Length; k++)
                {
                    if (vector[i] > vector[k])
                    {
                        var temp = vector[i];
                        vector[i] = vector[k];
                        vector[k] = temp;
                    }
                }
            }
            return vector;
        }

        public static double[] InsertionSort(double[] vector, int left = 0, int right = 0)
        {
            if (right == 0) right = vector.Length - 1;
            for(int j = left + 1; j <= right; j++)
            {
                var currentEl = vector[j];
                var i = j - 1;
                while((i >= left) && (vector[i] > currentEl))
                {
                    vector[i + 1] = vector[i];
                    i--;
                }
                vector[i + 1] = currentEl;
            }
            return vector;
        }
    }
}
