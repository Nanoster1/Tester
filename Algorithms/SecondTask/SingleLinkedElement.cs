namespace Algorithms.SecondTask
{
    public class SingleLinkedElement<T>
    {
        public SingleLinkedElement<T> NextElement { get; set; }
        public T Value { get; init; }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}