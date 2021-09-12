using System.Collections.Generic;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;

namespace Tester.Meta.Algorithms.FirstTask
{
    public abstract class FirstTask<TResult>: IAlgorithm
    {
        public abstract string Name { get; }
        public abstract TResult Start(Vector vector);
        public void TestRun(object[] @params)
        {
            Start(@params[0] as Vector);
        }
    }
}
