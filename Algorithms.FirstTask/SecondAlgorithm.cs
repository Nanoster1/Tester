using Tester.Meta.Interfaces;
using Tester.Meta.Models;

namespace Tester.Meta.Algorithms.FirstTask
{
    public class SecondAlgorithm : IAlgorithm
    {
        public string Name => nameof(SecondAlgorithm);
        public long Calculate(int[] vector)
        {
            long sum = 0;
            foreach (var element in vector)
                sum += element;
            return sum;
        }

        public void TestRun(object[] @params = null)
        {
            Calculate((int[])@params[0]);
        }
    }
}
