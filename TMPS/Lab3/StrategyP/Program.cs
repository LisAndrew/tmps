using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public interface ITravelStrategy
    {
        void GoToUniversity();
    }

   
  
    public class TaxiTravelStrategy : ITravelStrategy
    {
        public void GoToUniversity()
        {
            Console.WriteLine("Студент едет в универ на такси. Оплата - 70 лей");
        }
    }

    public class TrolleybusTravelStrategy : ITravelStrategy
    {
        public void GoToUniversity()
        {
            Console.WriteLine("Студент едет в универ на троллейбусе. Оплата - 2 лея");
        }
    }

    public class ScooterTravelStrategy : ITravelStrategy
    {
        public void GoToUniversity()
        {
            Console.WriteLine("Студент едет в универ на самокате. Оплата - 40 лей");
        }
    }

    public class TravelContext
    {
        private ITravelStrategy travelStrategy;
       
        public void SetTravelStrategy(ITravelStrategy strategy)
        {
            this.travelStrategy = strategy;
        }
        public void gotoUniversity()
        {
            travelStrategy.GoToUniversity();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Пожалуйста выберите тип поездки : Trolleybus or Scooter or Taxi");
            string travelType = Console.ReadLine();
            Console.WriteLine("Тип поездки : " + travelType);
            TravelContext ctx = null;
            ctx = new TravelContext();
            if ("Trolleybus".Equals(travelType, StringComparison.InvariantCultureIgnoreCase))
            {
                ctx.SetTravelStrategy(new TrolleybusTravelStrategy());
            }
            else if ("Scooter".Equals(travelType, StringComparison.InvariantCultureIgnoreCase))
            {
                ctx.SetTravelStrategy(new ScooterTravelStrategy());
            }
            else if ("Taxi".Equals(travelType, StringComparison.InvariantCultureIgnoreCase))
            {
                ctx.SetTravelStrategy(new TaxiTravelStrategy());
            }
           
            ctx.gotoUniversity();

            Console.Read();
        }
    }
}
