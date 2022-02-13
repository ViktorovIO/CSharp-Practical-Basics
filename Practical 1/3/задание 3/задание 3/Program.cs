using System;

namespace задание_3
{
    public static class ParseToInt
    {
        public static int ToInt(this string str)
        {
            return (int.Parse(str));
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var arg1 = "100500";

            Console.Write(arg1.ToInt() + "42".ToInt());

            Console.WriteLine(Convert.ToInt32(arg1) + Convert.ToInt32("42"));
            Console.Write(int.Parse(arg1) + int.Parse("42"));
            Console.ReadKey();
        }


    }
}
