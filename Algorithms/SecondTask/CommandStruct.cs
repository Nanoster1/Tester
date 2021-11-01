using System;
using System.Collections.Generic;
using System.Reflection;

namespace Algorithms.FirstTask.SecondTask
{
    public class CommandStruct<T>: ICommandStruct<T>
    {
        public object DataStruct { get; }
        public event Action<string> PrintActivate = (string value) => { };
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataStruct">Data struct</param>
        /// <param name="name">Data struct's name</param>
        /// <param name="type">Data struct's type</param>
        /// <param name="printAction">Method for subscribe on the print event</param>
        public CommandStruct(object dataStruct, string name,Type type = null, Action<string> printAction = null)
        {
            DataStruct = dataStruct;
            Name = name;
            if (printAction is not null) PrintActivate += printAction;
        }
        
        public string Name { get; set; } 

        public void AddCommand(T value)
        {
            switch (DataStruct)
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

        public T RemoveCommand() => DataStruct switch
        {
            Algorithms.SecondTask.Stack<T> stack => stack.Pop(),
            Algorithms.SecondTask.Queue<T> queue => queue.Dequeue(),
            _ => throw new NotSupportedException()
        };

        public T PeekCommand() => DataStruct switch
        {
            Algorithms.SecondTask.Stack<T> stack => stack.Top,
            Algorithms.SecondTask.Queue<T> queue => queue.Peek,
            _ => throw new NotSupportedException()
        };

        public bool IsEmptyCommand() => DataStruct switch
        {
            Algorithms.SecondTask.Stack<T> stack => stack.IsEmpty,
            Algorithms.SecondTask.Queue<T> queue => queue.IsEmpty,
            _ => throw new NotSupportedException()
        };

        public string PrintCommand()
        {
            var value = DataStruct switch
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