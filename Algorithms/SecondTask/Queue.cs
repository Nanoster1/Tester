using System.Collections;
using System.Collections.Generic;

namespace Algorithms.SecondTask
{
    public class Queue<T>: IEnumerable<T>, IReadOnlyCollection<T>
    {
        private SingleLinkedElement<T> _first;
        private SingleLinkedElement<T> _last;
        
        public int Count { get; private set; } = 0;
        public bool IsEmpty => Count == 0;
        public T Peek => _first.Value;
        
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
            var element = _first;
            _first = _first.NextElement;
            Count--;
            return element.Value;
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
            System.Text.StringBuilder @string = new();
            foreach (var element in this)
                @string.Append($"{element.ToString()} ");
            return @string.ToString().Trim().Replace(" ", ", ");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}