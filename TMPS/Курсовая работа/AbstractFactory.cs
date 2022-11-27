using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Models
{
    public interface ITour
    {
        TourA CreateHotel();
        TourB CreateTravel();
        int IPayment();
    }

    class PremiumTour : ITour
    {
        public TourA CreateHotel()
        {
            return new LuxaryHotel();
        }

        public TourB CreateTravel()
        {
            return new FirstClassTravel();
        }
        public int IPayment()
        {
   
            return 1500;
        }
    }

    class RegularTour : ITour
    {
        public TourA CreateHotel()
        {
            return new StandartHotel();
        }

        public TourB CreateTravel()
        {
            return new BusinessClassTravel();
        }

        public int IPayment()
        {
            return 800;
        }
    }

    class BudgetTour : ITour
    {
        public TourA CreateHotel()
        {
            return new BudgetHotel();
        }

        public TourB CreateTravel()
        {
            return new BudgetClassTravel();
        }
        public int IPayment()
        {
            return 400;

        }

    }

    public interface TourA
    {
        string UsefulFunctionA();
    }


    class LuxaryHotel : TourA
    {
        public string UsefulFunctionA()
        {
            return "\nТак как вы выбрали Premium тур, Вы будете жить в самом лучшем отеле\n - 5 звездочном !";
        }
    }

    class StandartHotel : TourA
    {
        public string UsefulFunctionA()
        {
            return "\nТак как вы выбрали Standard тур, Вы будете жить в стандартном отеле - 4 звезды!";
        }
    }

    class BudgetHotel : TourA
    {
        public string UsefulFunctionA()
        {
            return "\nТак как вы выбрали Budget тур, Вы будете жить в отеле - 3 звезды!";
        }
    }

    public interface TourB
    {
        string UsefulFunctionB();
    }

    class FirstClassTravel : TourB
    {
        public string UsefulFunctionB()
        {
            return "Поздравляем! Ваш перелет будет первым классом!";

        }

    }

    class BusinessClassTravel : TourB
    {
        public string UsefulFunctionB()
        {
            return "Ваш перелет будет произведен бизнес классом!";
        }

    }
    class BudgetClassTravel : TourB
    {
        public string UsefulFunctionB()
        {
            return "Ваш перелет будет бюджетным рейсом !";
        }

    }
}
