using System.Threading.Tasks;
using Tester.Meta.Interfaces;

namespace Tester.Meta.Testers
{
    public abstract class Tester<TResult>
    {
        public abstract void Test(IAlgorithm algorithm);
        public virtual async Task TestAsync(IAlgorithm algorithm) => await Task.Run(() => Test(algorithm));
        public abstract TResult Result { get; protected set; }
    }
}
