using System.Collections.Generic;
using Algorithms.SecondTask;

namespace Algorithms.FirstTask.SecondTask
{
    public class CommandsElement<T>
    {
        public List<string> Operations { get; init; }
        public System.Collections.Generic.Queue<T> Arguments { get; init; }
        public string Name { get; init; }
    }
}