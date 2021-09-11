using Tester.Meta.Interfaces;
using Tester.Meta.Models;

namespace Tester.Meta.Algorithms.FirstTask
{
    public abstract class FirstTask<TResult>: IAlgorithm
    {
        protected Vector Vector => Vector.RandomGenerate();
        public abstract TResult Start();

        public void TestRun()
        {
            Start();
        }
    }
}
