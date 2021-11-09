using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.FirstTask.ThirtTask
{
    public class List<T>: IEnumerable<T> where T: IComparable<T>
    {
        private TwoLinkedElement<T> _first = null;
        private TwoLinkedElement<T> _last = null;
        public T First { get => _first.Value; }
        public IEnumerator<T> GetEnumerator()
        {
            var element = _first;
            while (element is not null)
            {
                yield return element.Value;
                element = element.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            var element = new TwoLinkedElement<T>()
            {
                Value = item,
                Before = _last
            };
            if (_first is null && _last is null)
            {
                _first = element;
                _last = element;
            }
            else
            {
                _last.Next = element;
                element.Before = _last;
                _last = element;
            }

            Count++;
        }

        public void Clear()
        {
            _first = null;
            _last = null;
            Count = 0;
        }

        public int Count { get; private set; }
        public int IndexOf(T item)
        {
            throw new System.NotImplementedException();
        }

        public T this[int index]
        {
            get
            {
                var i = 0;
                foreach (var element in this)
                {
                    if (i == index)
                        return element;
                    i++;
                }

                throw new IndexOutOfRangeException();
            }
            set => throw new System.NotImplementedException();
        }

        public void Reverse()
        {
            var currentElement = _last;
            while (currentElement is not null)
            {
                currentElement.Next = currentElement.Before;
                var nextElement = currentElement.Before;
                currentElement.Before = null;
                currentElement = nextElement;
            }
        }

        public void ArrangeInsert(T E)
        {
            var newElement = new TwoLinkedElement<T>() {Value = E};
            var element = _first;
            while (element is not null)
            {
                if (element < newElement && element.Next > newElement)
                {
                    var nextElement = element.Next;
                    element.Next = newElement;
                    newElement.Before = element;
                    newElement.Next = nextElement;
                    newElement.Before = newElement;
                }
            }
        }

        public void InsertBefore(T E, T F)
        {
            var neededElement = new TwoLinkedElement<T>() {Value = E};
            var newElement = new TwoLinkedElement<T>() {Value = F};
            var element = _first;
            while (element is not null)
            {
                if (element == neededElement)
                {
                    var beforeElement = element.Before;
                    beforeElement.Next = newElement;
                    newElement.Before = beforeElement;
                    newElement.Next = element;
                    element.Before = newElement;
                }
            }
        }

        public void DoubleList()
        {
            foreach (var element in this)
            {
                var newElement = new TwoLinkedElement<T>()
                {
                    Value = element,
                    Before = _last
                };
                _last.Next = newElement;
                _last = newElement;
            }
        }

        public void SwapElements(T value1, T value2)
        {
            var element1 = new TwoLinkedElement<T>() {Value = value1};
            var element2 = new TwoLinkedElement<T>() {Value = value2};
            var element = _first;
            while (element is not null)
            {
                if (element == element1)
                {
                    element2.Before = element.Before;
                    element2.Next = element.Next;
                    element.Before.Next = element2;
                    element.Next.Before = element2;
                }
                else if (element == element2)
                {
                    element1.Before = element.Before;
                    element1.Next = element.Next;
                    element.Before.Next = element1;
                    element.Next.Before = element1;
                }
            }
        }
    }

    internal class TwoLinkedElement<T>
    where T: IComparable<T>
    {
        public TwoLinkedElement<T> Next { get; set; }
        public TwoLinkedElement<T> Before { get; set; }
        public T Value { get; set; }

        public static bool operator >(TwoLinkedElement<T> element1, TwoLinkedElement<T> element2)
        {
            return element1.Value.CompareTo(element2.Value) == 1;
        }

        public static bool operator <(TwoLinkedElement<T> element1, TwoLinkedElement<T> element2)
        {
            return element1.Value.CompareTo(element2.Value) == -1;
        }

        public static bool operator ==(TwoLinkedElement<T> element1, TwoLinkedElement<T> element2)
        {
            return element1.Value.CompareTo(element2.Value) == 0;
        }

        public static bool operator !=(TwoLinkedElement<T> element1, TwoLinkedElement<T> element2)
        {
            return !(element1 == element2);
        }
    }
}