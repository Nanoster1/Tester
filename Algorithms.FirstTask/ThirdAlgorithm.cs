using System.Numerics;
using Tester.Meta.Interfaces;
using Vector = Tester.Meta.Models.Vector;

namespace Tester.Meta.Algorithms.FirstTask
{
    public class ThirdAlgorithm : IAlgorithm
    {
        public string Name => nameof(ThirdAlgorithm);
        public BigInteger Calculate(int[] vector)
        {
            BigInteger value = new(1);
            foreach (var element in vector)
                value *= element;
            return value;
        }

        public void TestRun(object[] @params)
        {
            Calculate((int[])@params[0]);
        }
    }
}
