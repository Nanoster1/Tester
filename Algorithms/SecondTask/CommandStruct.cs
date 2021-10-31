using System;
using System.Collections.Generic;

namespace Algorithms.FirstTask.SecondTask
{
    public class CommandStruct<T>
    {
        private IEnumerable<T> _dataStruct;
        public event Action<string> PrintActivate = (string value) => { };
        
        public CommandStruct(IEnumerable<T> dataStruct, string name, Action<string> printAction = null)
        {
            _dataStruct = dataStruct;
            Name = name;
            if (printAction is not null) PrintActivate += printAction;
        }
        
        public string Name { get; set; } 

        public void AddCommand(T value)
        {
            switch (_dataStruct)
            {
                case Algorithms.SecondTask.Stack<T> stack:
                    stack.Push(value);
                    break;
                case Algorithms.SecondTask.Queue<T> queue:
                    queue.Enqueue(value);
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        public T RemoveCommand() => _dataStruct switch
        {
            Algorithms.SecondTask.Stack<T> stack => stack.Pop(),
            Algorithms.SecondTask.Queue<T> queue => queue.Dequeue(),
            _ => throw new NotSupportedException()
        };

        public T PeekCommand() => _dataStruct switch
        {
            Algorithms.SecondTask.Stack<T> stack => stack.Top,
            Algorithms.SecondTask.Queue<T> queue => queue.Peek,
            _ => throw new NotSupportedException()
        };

        public bool IsEmptyCommand() => _dataStruct switch
        {
            Algorithms.SecondTask.Stack<T> stack => stack.IsEmpty,
            Algorithms.SecondTask.Queue<T> queue => queue.IsEmpty,
            _ => throw new NotSupportedException()
        };

        public string PrintCommand()
        {
            var value = _dataStruct switch
            {
                Algorithms.SecondTask.Stack<T> stack => stack.ToString(),
                Algorithms.SecondTask.Queue<T> queue => queue.ToString(),
                _ => throw new NotSupportedException()
            };
            OnPrintActivate(value);
            return value;
        }

        protected virtual void OnPrintActivate(string value)
        {
            PrintActivate(value);
        }
    }
}