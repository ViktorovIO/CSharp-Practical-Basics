using System;

namespace _2_LAB
{
    public class Book
    {
        public string Title { get; set; }
    }
    
    public class Program 
    {
        public static void Check()
        {
            var book = new Book();
            book.Title = "Clean Code - Robert Martin";
            Console.WriteLine(book.Title);
        }
        static void Main(string[] args)
        {
            Check();
            Console.ReadKey();
        }
    }
}
