using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Models
{
   

    abstract class Tour
    {

        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string PassportId { get; set; }



        public Tour(string clientName, string clientSurname, string passportId)
        {
            ClientName = clientName;
            ClientSurname = clientSurname;
            PassportId = passportId;

        }

        // фабричный метод
        abstract public CountryTour CreateCountryTour();
    }

    class TurkeyTour : Tour
    {
        public TurkeyTour(string clientName, string clientSurname, string clientAddress) : base(clientName, clientSurname, clientAddress)
        {
            Console.Write("\n" + this.ClientName + " "
                        + this.ClientSurname +
                        " с номером паспорта " +
                        this.PassportId +
                        " выбрал поездку в Турцию !\n");
        
        }

        public override CountryTour CreateCountryTour()
        {
            return new TourInTurkey();
        }

    }

    class GreeceTour: Tour
    {
        public GreeceTour(string clientName, string clientSurname, string clientAddress) : base(clientName, clientSurname, clientAddress)
        {
            Console.Write("\n" + this.ClientName + " "
                        + this.ClientSurname +
                        " с номером паспорта " +
                        this.PassportId +
                        " выбрал поездку в Грецию!\n");
           

        }

        public override CountryTour CreateCountryTour()
        {
            return new TourInTurkey();
        }
    }

    class EgyptTour : Tour
    {
        public EgyptTour(string clientName, string clientSurname, string clientAddress) : base(clientName, clientSurname, clientAddress)
        {
            Console.Write("\n"+this.ClientName + " "
                        + this.ClientSurname +
                        " с номером паспорта " +
                        this.PassportId +
                        " выбрал поездку в Египет!\n");
          

        }

        public override CountryTour CreateCountryTour()
        {
            return new TourInEgypt();
        }
    }

    abstract class CountryTour
    {
         abstract public void someInformation();
    }

    class TourInTurkey : CountryTour
    {
        public TourInTurkey()
        {
            Console.WriteLine("Тур в Турцию оформлен!!\n");
        }
        public override void someInformation()
        {
            Console.WriteLine("=================================VACATION=======================================");
            Console.WriteLine("Информация о туре:\nТурция — это не только отличные пляжи четырех морей, но и великолепный Стамбул\nс Голубой мечетью и дворцом Топкапы, термальные источники Яловы и белоснежный\nПамуккале, монастыри Каппадокии, горные лыжи и классный шоппинг.");
            Console.WriteLine("\n=================================VACATION=======================================\n");
        }

    }
    class TourInGreece : CountryTour
    {
        public TourInGreece()
        {
            Console.WriteLine("Тур в Грецию оформлен!! \n");
        }
        public override void someInformation()
        {
            Console.WriteLine("=================================VACATION=======================================");
            Console.WriteLine("Информация о туре:\nГреция — страна, где древности на каждом шагу: Афины, Дельфы, Фивы и Метеоры,\nскальные монастыри и святая гора Афон. Еще здесь классные пляжи, чистое море,\nживописные острова и спа-отели. ");
            Console.WriteLine("\n=================================VACATION=======================================");
        }
    }
    class TourInEgypt : CountryTour
    {
        public TourInEgypt()
        {
            Console.WriteLine("Тур в Египет оформлен!! \n");
        }
        public override void someInformation()
        {
            Console.WriteLine("=================================VACATION=======================================");
            Console.WriteLine("Информация о туре:\nДостоинства Египта известны каждому: качественный пляжный отдых круглый год\nна Средиземном и Красном морях, разбавленный отличным дайвингом,\nплюс разнообразная «экскурсионка»:пирамиды, Сфинкс и Луксор. ");
            Console.WriteLine("\n=================================VACATION=======================================");
        }
    }
}

