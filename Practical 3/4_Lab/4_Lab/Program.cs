using System;
using System.Globalization;
namespace _4_Lab
{
    public class Ratio {
        public Ratio(int num, int den)
        {
            if (den <= 0)
                throw new ArgumentException("Знаменатель по условию больше нуля!");
            Numerator = num;
            Denominator = den;
            Value = Numerator * 1.0 / Denominator;
        }
        public readonly int Numerator;
        public readonly int Denominator;
        public readonly double Value;
    }
    class Program
    {
        public static void Check(int num, int den)
        {
            var ratio = new Ratio(num, den);
            Console.WriteLine("{0}/{1} = {2}", ratio.Numerator, ratio.Denominator, ratio.Value.ToString(CultureInfo.InvariantCulture));
        }
        static void Main(string[] args)
        {
            Check(50, 2);
            Console.ReadKey();
        }
    }
}
