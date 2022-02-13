using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_2
{
    class MenuItem
    {
        public string Caption;
        public string HotKey;
        public MenuItem[] Items;
    }
    static class Programm
    {
        public static MenuItem[] GenerateMenu()
        {
            return new[] 
            {
                new MenuItem()
                {
                    Caption = "File",
                    HotKey = "F",
                    Items = new[]
                    {
                        new MenuItem
                        {
                            Caption = "New",
                            HotKey = "N"
                        },
                        new MenuItem
                        {
                            Caption = "Save",
                            HotKey = "S"
                        }
                    }
                },
                new MenuItem
                {
                    Caption = "Edit",
                    HotKey = "E",
                    Items = new[]
                    {
                        new MenuItem
                        {
                            Caption = "Copy",
                            HotKey = "C"
                        },
                        new MenuItem
                        {
                            Caption = "Paste",
                            HotKey = "V"
                        }
                    }
                }
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}




