using System;

namespace Задание_5
{
    class Book : IComparable
    {
        public string Title;
        public int Theme;
        public int CompareTo(object obj)
        {
            var book = obj as Book;
            if (Theme.CompareTo(book.Theme) == 0)
                return Title.CompareTo(book.Title);
            else return Theme.CompareTo(book.Theme);
        }
    }
    class Program
    {

        static void Main(string[] args)
        {

        }
    }
}
