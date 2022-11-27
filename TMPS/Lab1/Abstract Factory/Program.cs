using System;


namespace AbstractFactory
{
    public interface Development
    {
        DevelopmentA CreateDesigner();
        DevelopmentB CreateDeveloper();
    }

    class AndroidDevelopment : Development
    {
        public DevelopmentA CreateDesigner()
        {
            return new AndroidDesigner();
        }

        public DevelopmentB CreateDeveloper()
        {
            return new AndroidDeveloper();
        }
    }

    class iOSDevelopment : Development
    {
        public DevelopmentA CreateDesigner()
        {
            return new iOSDesigner();
        }

        public DevelopmentB CreateDeveloper()
        {
            return new iOSDeveloper();
        }
    }

    public interface DevelopmentA
    {
        string UsefulFunctionA();
    }

   
    class AndroidDesigner : DevelopmentA
    {
        public string UsefulFunctionA()
        {
            return "Дизайнер для андроид приложения найден !";
        }
    }

    class iOSDesigner : DevelopmentA
    {
        public string UsefulFunctionA()
        {
            return "Дизайнер для iOs приложения найден !";
        }
    }

    public interface DevelopmentB
    {
        string UsefulFunctionB();
    }

    class AndroidDeveloper : DevelopmentB
    {
        public string UsefulFunctionB()
        {
            return "Разработчик для андроид приложения найден !";
        }

    }

    class iOSDeveloper : DevelopmentB
    {
        public string UsefulFunctionB()
        {
            return "Разработчик для iOS приложения найден !";
        }

    }
    class Client
    {
        public void Main()
        {
            
            Console.WriteLine("Создаем андроид приложение!!!");
            ClientMethod(new AndroidDevelopment());
            Console.WriteLine();

            Console.WriteLine("Создаем iOS приложение!!!");
            ClientMethod(new iOSDevelopment());
        }

        public void ClientMethod(Development development)
        {
            var appA = development.CreateDesigner();
            var appB = development.CreateDeveloper();

            Console.WriteLine(appA.UsefulFunctionA());
            Console.WriteLine(appB.UsefulFunctionB());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();

            Console.ReadKey();
        }
    }
}

