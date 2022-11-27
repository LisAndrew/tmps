using System;


namespace Decorator
{

    abstract class IceCream
    {
       abstract public void recipe();
 
    }

    //concrete component
    class IceCreamA : IceCream
    {

        public override void recipe()
        {
            Console.WriteLine("Обычное мороженое!");
        }

    }

    //decorator
    class Decorator : IceCream
    {

        private IceCream iceCream;
        public Decorator(IceCream iceCream)
        {

            this.iceCream = iceCream;
        }

        public override void recipe()
        {
            iceCream.recipe();

        }
        
    }

    //concrete decorator
    class IceCreamADecorator : Decorator
    {
        public IceCreamADecorator(IceCream iceCream) : base(iceCream)
        {
            Console.WriteLine("========Мороженое с m&m========");
        }

        public override void recipe()
        {
            base.recipe();
            recipeZZ();
        }

        public void recipeZZ()
        {
            Console.WriteLine("Добавьте m&m");
        }
    }
    //concrete decorator
    class IceCreamBDecorator : Decorator
    {
        public IceCreamBDecorator(IceCream iceCream) : base(iceCream)
        {
            Console.WriteLine("======Мороженое со взбитыми сливками======");
        }

        public override void recipe()
        {
            base.recipe();
            recipeHD();
        }

        public void recipeHD()
        {
            Console.WriteLine("Добавьте взбитых сливок");
        }
    }
     
    public class Client
    {
        public static void Main()
        {
            IceCream iceCream = new IceCreamA();

            Decorator decorator = new IceCreamADecorator(new IceCreamBDecorator(iceCream));
            decorator.recipe();
            
            Console.ReadKey();

        
        }
    }
}
