using System;

namespace Задание_4
{
    class Program
    {
        static object Min(Array array)
        {
            Array.Sort(array);
            return array.GetValue(0);
        }
        public static void Main()
        {
            Console.WriteLine(Min(new[] { 3, 6, 2, 4 }));
            Console.WriteLine(Min(new[] { "B", "A", "C", "D" }));
            Console.WriteLine(Min(new[] { '4', '2', '7' }));
        }
    }
}
