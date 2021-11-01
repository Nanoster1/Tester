using System;
using System.Collections.Generic;

namespace Algorithms.FirstTask.SecondTask
{
    public interface ICommandStruct<out T>
    {
        public object DataStruct { get; }
        public string Name { get; }
    }
}