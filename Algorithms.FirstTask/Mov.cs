namespace Algorithms.FirstTask
{
    public static class Mov
    {
        public static double Calculate(double[] vector)
        {
            double result = 1;
            foreach (var element in vector)
            {
                result *= element;
            }
            return result;
        }
    }
}
