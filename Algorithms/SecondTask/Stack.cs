using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.SecondTask
{
    public class Stack<T>: IEnumerable<T>, IReadOnlyCollection<T>
    {
        private SingleLinkedElement<T> _top = null;
        
        public T Top => _top.Value;
        public int Count { get; private set; } = 0;

        public void Push(T value)
        {
            _top = new SingleLinkedElement<T>() {Value = value, NextElement = _top};
            Count++;
        }

        public T Pop()
        {
            var value = _top.Value ?? throw new Exception("Stack is empty");
            _top = _top.NextElement;
            Count--;
            return value;
        }
        
        public bool IsEmpty => Count == 0;

        public IEnumerator<T> GetEnumerator()
        {
            var element = _top;
            while (element is not null)
            {
                yield return element.Value;
                element = element.NextElement;
            }
        }

        public override string ToString()
        {
            System.Text.StringBuilder @string = new();
            foreach(var element in this)
                @string.Append($"{element.ToString()} ");
            return @string.ToString().Trim().Replace(" ", ", ");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}