using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    //flyweight
    abstract class Pizza
    {
        //внутреннее состояние
        protected string Name;
        protected string Cheese;
        protected string Toppings;
        protected decimal Price;

        public abstract void Display(int orderTotal);
    }
    //context
    class Prosciutto : Pizza
    {
        public Prosciutto()
        {
            Name = "Prosciutto";
            Cheese = "Parmesan";
            Toppings = "Tomato sauce,Mushrooms,Olive oil,Black pepper";
            Price = 100;
        }

        public override void Display(int orderTotal)
        {
            Console.WriteLine("Pizza #" + orderTotal + ": "
                             + Name + " - topped with "
                             + Cheese + " cheese and "
                             + Toppings + "!" + Price.ToString() + " lei");
        }
    }

  
    class Marinara : Pizza
    {
        public Marinara()
        {
            Name = "Marinara";
            Cheese = "Swiss";
            Toppings = "Lettuce, Onion, Tomato,Pickles";
            Price = 99;
        }

        public override void Display(int orderTotal)
        {
            Console.WriteLine("Pizza #" + orderTotal + ": "
                               + Name + " - topped with "
                               + Cheese + " cheese and "
                               + Toppings + "!" + Price.ToString() + " lei");
        }

    }

    class Margherita : Pizza
    {
        public Margherita()
        {
            Name = "Margherita";
            Cheese = "Mozzarella";
            Toppings = "Tomato sauce,Fresh Basil,Olive oil,Black pepper";
            Price = 150;
        }

        public override void Display(int orderTotal)
        {
            Console.WriteLine("Pizza #" + orderTotal + ": "
                              + Name + " - topped with "
                              + Cheese + " cheese and "
                              + Toppings  + "!"+ Price.ToString() + " lei");
        }
    }

  
    class PizzaFactory
    {
        private Dictionary<char, Pizza> _pizzas = new Dictionary<char,Pizza>();

        public Pizza GetPizza(char key)
        {
           Pizza pizza = null;

         
            if (_pizzas.ContainsKey(key))
            {
                pizza = _pizzas[key];
            }
            else 
            {
                switch (key)
                {
                    case 'M': pizza = new Margherita(); break;
                    case 'A': pizza = new Marinara(); break;
                    case 'P': pizza = new Prosciutto(); break;
                }
                _pizzas.Add(key, pizza);
            }
            return pizza;
        }
    }
    class Program
    {
        static void Main()
        {
           
            Console.WriteLine("Введите букву для заказа (M-Margherita,A-Marinara,P-Prosciutto без пробелов):");
            var order = Console.ReadLine();
            char[] chars = order.ToCharArray();

            PizzaFactory factory = new PizzaFactory();

            int orderTotal = 0;

            //Получаем пиццу из factory
            foreach (char c in chars)
            {
                orderTotal++;
                Pizza character = factory.GetPizza(c);
                character.Display(orderTotal);
            }

            Console.ReadKey();
        }
    }
}
