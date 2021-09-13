using Tester.Meta.Interfaces;
using Tester.Meta.Models;

namespace Tester.Meta.Algorithms.FirstTask
{
    public class FirstAlgorithm : IAlgorithm
    {
        public string Name => nameof(FirstAlgorithm);
        public int Calculate(int[] vector)
        {
            return 1;
        }

        public void TestRun(object[] @params = null)
        {
            Calculate((int[])@params[0]);
        }
    }
}
