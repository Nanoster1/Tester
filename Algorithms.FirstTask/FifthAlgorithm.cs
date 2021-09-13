using Tester.Meta.Interfaces;
using Tester.Meta.Models;

namespace Tester.Meta.Algorithms.FirstTask
{
    public class FifthAlgorithm : IAlgorithm
    {
        public string Name => nameof(FifthAlgorithm);

        public void Sort(int[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                for (int k = i + 1; k < vector.Length; k++)
                {
                    if (vector[i] > vector[k])
                    {
                        var temp = vector[i];
                        vector[i] = vector[k];
                        vector[k] = temp;
                    }
                }
            }
        }

        public void TestRun(object[] @params = null)
        {
            Sort((int[])@params[0]);
        }
    }
}
