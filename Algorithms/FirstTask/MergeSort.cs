using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.FirstTask
{
    public class MergeSort
    {
        public static double[] Sort(double[] arr)
        {
            if (arr.Length > 1)
            {
                var left = new double[arr.Length / 2];
                var right = new double[arr.Length - left.Length];
                for (int i = 0; i < left.Length; i++)
                {
                    left[i] = arr[i];
                }
                for (int j = 0; j < right.Length; j++)
                {
                    right[j] = arr[left.Length + j];
                }
                if (left.Length > 1)
                    left = Sort(left);
                if (right.Length > 1)
                    right = Sort(right);
                arr = Merge(left, right);
                return arr;
            }
            else
            {
                return arr;
            }
        }
        private static double[] Merge(double[] left, double[] right)
        {
            var result = new double[left.Length + right.Length];
            int i = 0, j = 0;
            for (int k = 0; k < result.Length; k++)
            {
                if (i > left.Length - 1)
                {
                    result[k] = right[j];
                    j++;
                }
                else if (j > right.Length - 1)
                {
                    result[k] = left[i];
                    i++;
                }
                else if (left[i] >= right[j])
                {
                    result[k] = right[j];
                    j++;
                }
                else
                {
                    result[k] = left[i];
                    i++;
                }
            }
            return result;
        }
        public static char[] Sort(char[] arr)
        {
            if (arr.Length > 1)
            {
                var left = new char[arr.Length / 2];
                var right = new char[arr.Length - left.Length];
                for (int i = 0; i < left.Length; i++)
                {
                    left[i] = arr[i];
                }
                for (int j = 0; j < right.Length; j++)
                {
                    right[j] = arr[left.Length + j];
                }
                if (left.Length > 1)
                    left = Sort(left);
                if (right.Length > 1)
                    right = Sort(right);
                arr = Merge(left, right);
                return arr;
            }
            else
            {
                return arr;
            }
        }
        private static char[] Merge(char[] left, char[] right)
        {
            var result = new char[left.Length + right.Length];
            int i = 0, j = 0;
            for (int k = 0; k < result.Length; k++)
            {
                if (i > left.Length - 1)
                {
                    result[k] = right[j];
                    j++;
                }
                else if (j > right.Length - 1)
                {
                    result[k] = left[i];
                    i++;
                }
                else if (left[i] >= right[j])
                {
                    result[k] = right[j];
                    j++;
                }
                else
                {
                    result[k] = left[i];
                    i++;
                }
            }
            return result;
        }
    }
}
