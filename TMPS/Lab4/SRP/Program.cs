using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Single_Responsibility
{
    //как не надо делать
    class Report
    {
        public string Text { get; set; } = "Если не будете использовать Single Resposibility повязнете в грязи(";
        public void GoToFirstPage() =>
            Console.WriteLine("Переход к первой странице");

        public void GoToLastPage() =>
            Console.WriteLine("Переход к последней странице");

        public void GoToPage(int pageNumber) =>
            Console.WriteLine($"Переход к странице {pageNumber}");


        public void Print()
        {
            Console.WriteLine("Печать отчета");
            Console.WriteLine(Text);
        }
    }

    //как надо делать
    class Report2
    {
        public string Text { get; set; } = "Используйте Single Resposibility и будет вам счастье!";
        public void GoToFirstPage() =>
            Console.WriteLine("Переход к первой странице");

        public void GoToLastPage() =>
            Console.WriteLine("Переход к последней странице");

        public void GoToPage(int pageNumber) =>
            Console.WriteLine($"Переход к странице {pageNumber}");
    }

    //  обязанность - печать отчета
    class Printer
    {
        public void PrintReport(Report2 report)
        {
            Console.WriteLine("Печать отчета");
            Console.WriteLine(report.Text);
        }
    }
        

class Program
    {
        static void Main()
        {
            Report report = new Report();
            report.GoToFirstPage();
            report.GoToPage(4);
            report.Print();
            Console.WriteLine("===================");
            Report2 report2 = new Report2();
            report2.GoToPage(4);
            Printer printer = new Printer();
            printer.PrintReport(report2);



            Console.ReadKey();
        }
    }

   
}
