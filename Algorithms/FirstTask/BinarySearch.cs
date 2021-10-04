using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.FirstTask
{
    
    public static class BinarySearch
    {
        public static int Search(int[] arr, int num)
        {
            int lowIndex = 0;
            int highIndex = arr.Length - 1;
            while (lowIndex <= highIndex)
            {
                int middle = lowIndex + (highIndex - lowIndex) / 2;
                if (num < arr[middle])
                    highIndex = middle - 1;
                if (num > arr[middle])
                    lowIndex = middle + 1;
                else
                    return middle + 1;
            }
            return -1;
        }
    }
}
