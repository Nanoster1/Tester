using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ListGeneration
    {
        public static int[] Generation(int n)
        {
            int[] arr = new int[2];
            while (arr.Length < n)
                arr = new int[arr.Length * 2];
            arr[n] = n;
            return arr;
        }
    }
}
