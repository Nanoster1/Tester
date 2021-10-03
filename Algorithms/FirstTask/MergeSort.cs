using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MergeSort
    {
        public static int[] Sort(int[] arr)
        {
            if (arr.Length > 1)
            {
                int[] left = new int[arr.Length / 2];
                int[] right = new int[arr.Length - left.Length];
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
        public static int[] Merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];
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
