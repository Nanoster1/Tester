namespace Algorithms.SecondTask
{
    internal class SingleLinkedElement<T>
    {
        internal SingleLinkedElement<T> NextElement { get; set; }
        internal T Value { get; init; }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}