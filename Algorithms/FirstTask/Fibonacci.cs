﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Fibonacci
    { 
        public static int FibRec(int n)
        {
            return n > 1 ? FibRec(n - 1) + FibRec(n - 2) : n;
        }
    }
}
