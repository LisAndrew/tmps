using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_inversion
{
    class Book
    {
        public string Text { get; set; }
        public ConsolePrinter Printer { get; set; }

        public void Print()
        {
            Printer.Print(Text);
        }
    }

    class ConsolePrinter
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }

    //best aproach
    interface IPrinter
    {
        void Print(string text);
    }

    class Book2
    {
        public string Text { get; set; }
        public IPrinter Printer { get; set; }

        public Book2(IPrinter printer)
        {
            this.Printer = printer;
        }

        public void Print()
        {
            Printer.Print(Text);
        }
    }

    class ConsolePrinter2 : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine("Печать на консоли");
        }
    }

    class HtmlPrinter : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine("Печать в html");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Book2 book = new Book2(new ConsolePrinter2());
            book.Print();
            book.Printer = new HtmlPrinter();
            book.Print();
            Console.ReadKey();
        }
    }
}
