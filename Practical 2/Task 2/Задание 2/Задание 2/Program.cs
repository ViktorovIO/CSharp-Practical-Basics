using System;
using System.Collections.Generic;
using System.Linq;

namespace Задание_2
{
    class Program
    {
        private static Array Combine(params Array[] args)
        {
            if (args.Length > 0)
            {
                var type = args[0].GetType();
                if (args.Any(array => array.GetType() != type)) return null;
                var newArray = new List<object>();
                foreach (var array in args)
                {
                    newArray.AddRange(array.Cast<object>());
                }

                return newArray.ToArray();

            }
            return null;
        }
        static void Print(Array array)
        {
            if (array == null)
            {
                Console.WriteLine("null");
                return;
            }
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0} ", array.GetValue(i));
            Console.WriteLine();
        }
        public static void Main()
        {
            var ints = new[] { 1, 2 };
            var strings = new[] { "A", "B" };

            Print(Combine(ints, ints));
            Print(Combine(ints, ints, ints));
            Print(Combine(ints)); Print(Combine());
            Print(Combine(strings, strings));
            Print(Combine(ints, strings));
        }

    }
}
