using System;

namespace ConsoleApp1
{
    class Program
    {
        public static void Print(params object[] printer)
        {
            for (var i = 0; i < printer.Length; i++)
            {
                if (i > 0)
                    Console.Write(", ");
                Console.Write(printer[i]);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Print(1, 5);
            Print(true, 7);
            Print("Hello", ", ", "World");
            Print(" ", false);
            Print("Ololo");
        }
    }
}
