using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.ThirtTask
{
    public class TwoLinkedList<T>: IEnumerable<T> where T: IComparable<T>
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
            _first = _last;
            while (currentElement is not null)
            {
                currentElement.Next = currentElement.Before;
                var nextElement = currentElement.Before;
                currentElement.Before = null;
                currentElement = nextElement;
            }
        }
        
        public void MoveElement(bool atTheEnd)
        {
            if (atTheEnd)
            {
                _last.Next = _first;
                _first.Before = _last;
                _last = _first;
                _first = _first.Next;
                _last.Next = null;
                _first.Before = null;
            }
            else
            {
                _first.Before = _last;
                _last.Next = _first;
                _first = _last;
                _last = _last.Before;
                _last.Next = null;
                _first.Before = null;
            }
            
        }

        public void ArrangeInsert(T e)
        {
            var newElement = new TwoLinkedElement<T>() {Value = e};
            var element = _first;
            while (element is not null)
            {
                if (element <= newElement && element.Next is not null && element.Next >= newElement)
                {
                    var nextElement = element.Next;
                    element.Next = newElement;
                    newElement.Before = element;
                    newElement.Next = nextElement;
                    newElement.Before = newElement;
                    return;
                }

                element = element.Next;
            }

            newElement.Before = _last;
            _last.Next = newElement;
            _last = newElement;
        }

        public void InsertBefore(T e, T f)
        {
            var neededElement = new TwoLinkedElement<T>() {Value = e};
            var newElement = new TwoLinkedElement<T>() {Value = f};
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
                    return;
                }

                element = element.Next;
            }
        }

        public void DoubleList()
        {
            var i = Count;
            foreach (var element in this)
            {
                var newElement = new TwoLinkedElement<T>()
                {
                    Value = element,
                    Before = _last
                };
                _last.Next = newElement;
                _last = newElement;
                if (--Count == 0) return;
            }
        }

        public void SwapElements(T value1, T value2)
        {
            var element1 = new TwoLinkedElement<T>() {Value = value1};
            var element2 = new TwoLinkedElement<T>() {Value = value2};
            var element = _first;
            while (element is not null)
            {
                if ((element1.Next is null && element1.Before is null) && element == element1)
                {
                    element1 = element;
                    if (element2.Next is not null || element2.Before is not null) break;
                }
                else if ((element2.Next is null && element2.Before is null) && element == element2)
                {
                    element2 = element;
                    if (element1.Next is not null || element1.Before is not null) break;
                }

                element = element.Next;
            }

            (element1.Value, element2.Value) = (element2.Value, element1.Value);
        }
    }

    internal class TwoLinkedElement<T> where T: IComparable<T>
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
        
        public static bool operator <=(TwoLinkedElement<T> element1, TwoLinkedElement<T> element2)
        {
            return element1.Value.CompareTo(element2.Value) is -1 or 0;
        }

        public static bool operator >=(TwoLinkedElement<T> element1, TwoLinkedElement<T> element2)
        {
            return element1.Value.CompareTo(element2.Value) is 1 or 0;
        }

        public static bool operator ==(TwoLinkedElement<T> element1, TwoLinkedElement<T> element2)
        {
            return element1.Value.CompareTo(element2.Value) == 0;
        }

        public static bool operator !=(TwoLinkedElement<T> element1, TwoLinkedElement<T> element2)
        {
            return !(element1 == element2);
        }
        
        protected bool Equals(TwoLinkedElement<T> other)
        {
            return Equals(Next, other.Next) && Equals(Before, other.Before) && EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TwoLinkedElement<T>) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Next, Before, Value);
        }
    }
}