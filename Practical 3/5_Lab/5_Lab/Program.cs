using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOnlyVectorTask
{
   class ReadOnlyVector
    {
        public ReadOnlyVector(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
            Length = Math.Sqrt(X * X + Y * Y);
        }
        public double Add(ReadOnlyVector other)
        {
            return other.X + other.Y;
        }
        public double WithX(double other_X)
        {
            return Math.Sqrt(other_X * other_X + Y * Y);
        }
        public double WithY(double other_Y)
        {
            return Math.Sqrt(X * X + other_Y * other_Y);
        }
        public override string ToString()
        {
            return string.Format("({0}, {1}) with length: {2}", X, Y, Length);
        }
        public readonly double X;
        public readonly double Y;
        public readonly double Length;
    }
    class Prpgram
    {
        public static void Check()
        {
            ReadOnlyVector vector = new ReadOnlyVector(3, 4);
            Console.WriteLine(vector.ToString());
            Console.WriteLine("Сумма: " + vector.Add(vector));
            double X_other = 5;
            double Y_other = 3;
            Console.WriteLine("Изменили вектор, X стал равным = " + X_other + " координаты стали: (" + X_other + ", 4) длина вектора равна: " + vector.WithX(X_other));
            Console.WriteLine("Изменили вектор, Y стал равным = " + Y_other + " координаты стали: (3, " + Y_other + ") длина вектора равна: " + vector.WithY(Y_other));
        }
        static void Main(string[] args)
        {
            Check();
            Console.ReadKey();
        }
    }
}
