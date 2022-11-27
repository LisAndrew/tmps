using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    public abstract class CoffeeTemplate
    {
        
        public void PrepareCoffee()
        {
            BoilWater();
            AddMilk();
            AddSugar();
            AddCoffeePowder();
            Console.WriteLine(this.GetType().Name + " готово!!!!!");
        }
        protected abstract void BoilWater();
        protected abstract void AddMilk();
        protected abstract void AddSugar();
        protected abstract void AddCoffeePowder();
    }
    public class JacobsCoffee : CoffeeTemplate
    {
        protected override void BoilWater()
        {
            Console.WriteLine("Вода добавлена");
        }
        protected override void AddMilk()
        {
            Console.WriteLine("Молоко добавлено");
        }
        protected override void AddSugar()
        {
            Console.WriteLine("Сахар добавлен");
        }
        protected override void AddCoffeePowder()
        {
            Console.WriteLine("Добавлен кофейный порошок Jacobs");
        }
    }
    public class NescafeCoffee : CoffeeTemplate
    {
        protected override void BoilWater()
        {
            Console.WriteLine("Вода добавлена");
        }
        protected override void AddMilk()
        {
            Console.WriteLine("Молоко добавлено");
        }
        protected override void AddSugar()
        {
            Console.WriteLine("Сахар добавлен");
        }
        protected override void AddCoffeePowder()
        {
            Console.WriteLine("Добавлен кофейный порошок Nescafe");
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Nescafe Coffee Preparation\n");
            CoffeeTemplate coffee = new NescafeCoffee();
            coffee.PrepareCoffee();
            Console.WriteLine("==========================\n");
            Console.WriteLine("Jacobs coffee preparation\n");
            coffee = new JacobsCoffee();
            coffee.PrepareCoffee();
            Console.Read();
        }
    }
}
