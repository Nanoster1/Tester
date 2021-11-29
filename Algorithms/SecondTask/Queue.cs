using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.SecondTask
{
    public class Queue<T>: IReadOnlyCollection<T>
    {
        private SingleLinkedElement<T> _first;
        private SingleLinkedElement<T> _last;
        
        public int Count { get; private set; } = 0;
        public bool IsEmpty => Count == 0;
        public T Peek => _last.Value ?? throw new Exception("Queue is empty");
        
        public void Enqueue(T value)
        {
            var element = new SingleLinkedElement<T>() { Value = value };
            if (_last != null) _last.NextElement = element;
            _last = element;
            _first ??= element;
            Count++;
        }
        
        public T Dequeue()
        {
            var value = _first.Value ?? throw new Exception("Queue is empty");
            _first = _first.NextElement;
            if (_first is null) _last = null;
            Count--;
            return value;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            var element = _first;
            while (element != null)
            {
                yield return element.Value;
                element = element.NextElement;
            }
        }

        public override string ToString()
        {
            return string.Join(", ", this).Trim();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}