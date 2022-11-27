using TravelAgency.Models;
using System.IO;
using System;
using AbstractFactory.Models;

namespace TravelAgency
{
    
    class Client
    {
        public double tourpayment;

        public void Main()
        {

           //FactoryMethod

            Console.WriteLine("=================================VACATION=======================================");
            Console.Write("Добрый день! Добро пожаловать в наше туристическое агентство!\nДля того, чтобы продолжить введите следующие данные:\n\nИмя: ");
            string clientName = (Console.ReadLine());
            Console.Write("Фамилия: ");
            string clientSurname = (Console.ReadLine());
            Console.Write("Номер паспорта: ");
            string passportId = (Console.ReadLine());
            Console.WriteLine("=================================VACATION=======================================");
            Console.Clear();
            Method();
            Console.Write("На данный момент доступны туры в страны: Турция, Греция, Египет\nВыберите желаемую страну:");
            string destination = (Console.ReadLine());
            CountryTour countryTour;
            switch (destination)
            {
                case "Турция":
                    new TurkeyTour(clientName, clientSurname, passportId);
                    countryTour = new TourInTurkey();
                    countryTour.someInformation();
                    break;

                case "Греция":
                    new GreeceTour(clientName, clientSurname, passportId);
                    countryTour = new TourInGreece();
                    countryTour.someInformation();
                    break;

                case "Египет":
                    new EgyptTour(clientName, clientSurname, passportId);
                    countryTour = new TourInEgypt();
                    countryTour.someInformation();
                    break;

            }


            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("=================================VACATION=======================================");
            
            //AbstractFactory
            Console.Write("Далее выберите тур в зависимости от стоимости (Premium, Regular, Budget)");
            string qualitytour = (Console.ReadLine());
            
            switch (qualitytour)
            {
                case "Premium": ClientMethod(new PremiumTour());
                    break;


                case "Regular":ClientMethod(new RegularTour());
                    break;

                case "Budget": ClientMethod(new BudgetTour());
                    break;

            }
            Console.WriteLine("=================================VACATION=======================================");
            Console.ReadKey();
            Console.Clear();

            //ChainofResposibiblity
            Console.WriteLine("=================================VACATION=======================================");
            Console.WriteLine("Валидация оформления тура!\n");
            System.Threading.Thread.Sleep(1500);
            ValidatorBase datevalidator = new DateAvailableValidator();
            ValidatorBase apartmentvalidator = new ApartmentAvailableValidator();
            ValidatorBase paymentvalidator = new PaymentValidator();
            datevalidator.SetSuccessor(apartmentvalidator);
            apartmentvalidator.SetSuccessor(paymentvalidator);
            Request p = new Request("дата");
            datevalidator.ProcessRequest(p);
            p = new Request("номер");
            datevalidator.ProcessRequest(p);
            p = new Request("оплата");
            datevalidator.ProcessRequest(p);
            IPayment payment = new PaymentValidator();
            double pay =payment.Payment(tourpayment, dis);
            Console.WriteLine("\n=================================VACATION=======================================");
            Console.ReadKey();
            Console.Clear();

            try
            {
               
                StreamWriter sw = new StreamWriter(@"D:\\Database.txt", true);
                sw.WriteLine("=================================VACATION=======================================" + Environment.NewLine);
                //Write a line of text
                sw.WriteLine("Имя: {0}"+Environment.NewLine+"Фамилия: {1}" + Environment.NewLine+"Тур: {2} " + Environment.NewLine+"Страна: {3}" + Environment.NewLine + "Дата тура: {4}" +Environment.NewLine+"Стоимость:{5} ", clientName,clientSurname,qualitytour,destination,p.RandomDay(), pay+"$");
                sw.WriteLine(Environment.NewLine+"=================================VACATION=======================================");
                //Write a second line of text

                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            //Strategy
            Console.WriteLine("=================================VACATION=======================================");
            Console.WriteLine("Пожалуйста выберите тип оплаты : Cash or E-wallet or Card");
            Console.Write("Тип оплаты : ");
            string paymentType = Console.ReadLine();
            PaymentContext ctx = new PaymentContext();
            if ("Cash".Equals(paymentType, StringComparison.InvariantCultureIgnoreCase))
            {
                ctx.SetPaymentStrategy(new CashPayment());
            }
            else if ("E-wallet".Equals(paymentType, StringComparison.InvariantCultureIgnoreCase))
            {
                ctx.SetPaymentStrategy(new EWalletPayment(clientName, clientSurname,passportId, qualitytour, destination, p.RandomDay(), pay + "$"));
            }

            else if ("Card".Equals(paymentType, StringComparison.InvariantCultureIgnoreCase))
            {
                ctx.SetPaymentStrategy(new CardPayment(clientName, clientSurname,passportId, qualitytour, destination, p.RandomDay(), pay + "$"));
            }

            ctx.payment();
            Console.WriteLine("=================================VACATION=======================================");
            Console.ReadKey();
            Console.Clear();

            //Facade
            Order order = new Order();
            order.PlaceOrder();
            Console.WriteLine("=================================VACATION=======================================");
            Console.Clear();

        }
        
        
        public double ClientMethod(ITour tour)
        {
            var appA = tour.CreateHotel();
            tourpayment = tour.IPayment();
            Console.WriteLine("\nСумма к оплате:"+ tour.IPayment());
            var appB = tour.CreateTravel();
            Console.WriteLine(appA.UsefulFunctionA());
            Console.WriteLine(appB.UsefulFunctionB());
            return tourpayment;
        }
        public double dis;
        //Bridge
        public void Method()
        {
            Console.WriteLine("=================================VACATION=======================================");
            Console.Write("Есть ли у вас промокод на первый тур? (да/нет) ");
            string answer = Console.ReadLine();
            Console.Write("Физическое или юридическое лицо? (Ю/Ф) ");
            string b = Console.ReadLine();
            if (answer == "да" && b == "Ю")
            {
                Person person = new LegalPerson(new DiscountAccount());
                IAccount discount = person.CreateAccount();
                discount.CreateAccount();
                dis = discount.CreateDiscount();


            }
            else if (answer == "нет" && b == "Ю")
            {
                Person person = new LegalPerson(new RegularAccount());
                person.CreateAccount();
                Console.WriteLine("=================================VACATION=======================================");

            }
            else if (answer == "да" && b == "Ф")
            {
                Person person = new NaturalPerson(new DiscountAccount());
                IAccount discount = person.CreateAccount();
                discount.CreateAccount();
                dis = discount.CreateDiscount();


            }
            else if (answer == "нет" && b == "Ф")
            {
                Person person = new NaturalPerson(new RegularAccount());
                person.CreateAccount();
                Console.WriteLine("=================================VACATION=======================================");
            }
            Console.WriteLine("=================================VACATION=======================================");
            Console.ReadKey();
            Console.Clear();
          
            
        }
    
    }
       
    class Program
    {
        static void Main()
        {
            
            new Client().Main();
         
            Console.WriteLine("Список всех клиентов компании:");
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("D:\\Database.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)

                {
                    //write the line to console window
                    Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            Console.ReadKey();
        }
    }
}
