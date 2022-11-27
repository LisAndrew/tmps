using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Closed
{
    //анти принцип
    class Cook
    {
        public string Name { get; set; }
        public Cook(string name)
        {
            this.Name = name;
        }

        public void MakeDinner()
        {
            Console.WriteLine("Чистим картошку");
            Console.WriteLine("Ставим почищенную картошку на огонь");
            Console.WriteLine("Сливаем остатки воды, разминаем варенный картофель в пюре");
            Console.WriteLine("Посыпаем пюре специями и зеленью");
            Console.WriteLine("Картофельное пюре готово");
        }
    }

    //хороший способ
    class Cook2
    {
        public string Name { get; set; }

        public Cook2(string name)
        {
            this.Name = name;
        }

        public void MakeDinner(IMeal meal)
        {
            meal.Make();
        }
    }

    interface IMeal
    {
        void Make();
    }
    class PotatoMeal : IMeal
    {
        public void Make()
        {
            Console.WriteLine("Чистим картошку");
            Console.WriteLine("Ставим почищенную картошку на огонь");
            Console.WriteLine("Сливаем остатки воды, разминаем варенный картофель в пюре");
            Console.WriteLine("Посыпаем пюре специями и зеленью");
            Console.WriteLine("Картофельное пюре готово");
        }
    }
    class SaladMeal : IMeal
    {
        public void Make()
        {
            Console.WriteLine("Нарезаем помидоры и огурцы");
            Console.WriteLine("Посыпаем зеленью, солью и специями");
            Console.WriteLine("Поливаем подсолнечным маслом");
            Console.WriteLine("Салат готов");
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Плохой способ");
            Console.WriteLine("================================");
            Cook bob = new Cook("Bob");
            bob.MakeDinner();
            Console.WriteLine("\n================================");
            Console.WriteLine("Хороший способ");
            Console.WriteLine("\n================================");
            Cook2 barbara = new Cook2("Barbara");
            barbara.MakeDinner(new PotatoMeal());
            Console.WriteLine();
            barbara.MakeDinner(new SaladMeal());
            Console.ReadKey();
        }
    }
}
