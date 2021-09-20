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
        
        private static void Merge(double[] arr, int left, int midle, int right)
        {
            int lenghtLeft = midle - left + 1, lenghtRight = right - midle;
            double[] leftArr = new double[lenghtLeft];
            double[] rightArr = new double[lenghtRight];
            for (int x = 0; x < lenghtLeft; x++)
                leftArr[x] = arr[left + x];
            for (int x = 0; x < lenghtRight; x++)
                rightArr[x] = arr[midle + 1 + x];

            int i = 0;
            int j = 0;
            int k = left;

            while (i < lenghtLeft && j < lenghtRight)
            {
                if (leftArr[i] <= rightArr[j])
                {
                    arr[k] = leftArr[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArr[j];
                    j++;
                }
                k++;
            }
            while (i < lenghtLeft)
            {
                arr[k] = leftArr[i];
                k++;
                i++;
            }
            while (j < lenghtRight)
            {
                arr[k] = rightArr[j];
                k++;
                j++;
            }
        }
        public static double[] TimSort(double[] arr)
        {
            static int GetMinrun(int n)
            {
                int r = 0;
                while (n >= 64)
                {
                    r |= n & 1;
                    n >>= 1;
                }
                return n + r;
            }
            var minRun = GetMinrun(arr.Length);
            var lenght = arr.Length;
            // Sort individual subarrays of size RUN
            for (int i = 0; i < lenght; i += minRun)
            {
                InsertionSort(arr, i, Math.Min((i + minRun - 1), (lenght - 1)));
            }
            for (int size = minRun; size < lenght; size = 2 * size)
            {
                for (int left = 0; left < lenght; left += 2 * size)
                {

                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (lenght - 1));

                    if (mid < right)
                    {
                        Merge(arr, left, mid, right);
                    }

                }
            }
            return arr;
        }
    }
}
