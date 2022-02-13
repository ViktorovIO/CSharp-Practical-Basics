using System;

namespace Задание_3
{
    class Program
    {
        static IComparable MiddleOfThree(params IComparable[] array)
        {
            Array.Sort(array);
            return array[1];
        }
        public static void Main()
        {
            Console.WriteLine(MiddleOfThree(2, 5, 4));
            Console.WriteLine(MiddleOfThree(3, 1, 2));
            Console.WriteLine(MiddleOfThree(3, 5, 9));
            Console.WriteLine(MiddleOfThree("B", "Z", "A"));
            Console.WriteLine(MiddleOfThree(3.45, 2.67, 3.12));
        }

    }
}
