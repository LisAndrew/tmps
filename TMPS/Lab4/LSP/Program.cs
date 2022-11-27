using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov_Substitution
{
    // without liskov substitution
    
    public class Apple
    {
        public virtual string GetColor()
        {
            return "Red";
        }
    }
    public class Orange : Apple
    {
        public override string GetColor()
        {
            return "Orange";
        }
    }

    //liskov substitution
    public abstract class Fruit
    {
        public abstract string GetColor();
    }
    public class Apple2 : Fruit
    {
        public override string GetColor()
        {
            return "Red";
        }
    }
    public class Orange2 : Fruit
    {
        public override string GetColor()
        {
            return "Orange";
        }
    }


    class Program
    {
        static void Main()
        {
            Apple apple = new Orange();
            Console.WriteLine(apple.GetColor());
            Console.WriteLine("===========");
            Fruit fruit = new Orange2();
            Console.WriteLine(fruit.GetColor());
            fruit = new Apple2();
            Console.WriteLine(fruit.GetColor());
            Console.WriteLine("===========");
            Apple apple2 = new Apple();
            Console.WriteLine(apple2.GetColor());

            Console.ReadKey();
        }
    }

}

