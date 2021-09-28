using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.FirstTask
{
    
    public static class BinarySearch
    {
        public static int [] Arr { get; set; }
        private static int Num { get; set; }
        public static void InputData(int[] arr, int num)
        {
            Arr = arr;
            Num = num;
        }
        public static int Search()
        {
            int lowIndex = 0;
            int highIndex = Arr.Length - 1;
            while (lowIndex <= highIndex)
            {
                int middle = lowIndex + (highIndex - lowIndex) / 2;
                if (Num < Arr[middle])
                    highIndex = middle - 1;
                if (Num > Arr[middle])
                    lowIndex = middle + 1;
                else
                    return middle + 1;
            }
            return -1;
        }
    }
}
