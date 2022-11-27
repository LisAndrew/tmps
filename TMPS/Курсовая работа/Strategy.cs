using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Models;

namespace AbstractFactory.Models
{
    public abstract class PersonalData
    {
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string PassportId { get; set; }
        public string QualityTour { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public string Pay { get; set; }

        public PersonalData(string clientName, string clientSurname, string passportId, string qualitytour, string destination, DateTime date, string pay)
        {
            ClientName = clientName;
            ClientSurname = clientSurname;
            PassportId = passportId;
            QualityTour = qualitytour;
            Destination = destination;
            Date = date;
            Pay = pay;

        }

    }
    public interface IPaymentStrategy
    {
        void Payment();
    }

   
    public class CashPayment : IPaymentStrategy
    {
        public void Payment()
        {
            Console.WriteLine("Для оплаты наличными приглашаем Вас в офис на улице Decebal 35");
        }
    }

    public class CardPayment : PersonalData, IPaymentStrategy
    {
        public CardPayment (string clientName, string clientSurname, string passportId, string qualitytour, string destination, DateTime date, string pay) : base(clientName, clientSurname,passportId, qualitytour,destination, date,  pay)
        {
            Console.Write("\nИмя:" + this.ClientName + "\nФамилия: "
                       + this.ClientSurname +
                       "\nНомер паспорта: " +
                       this.PassportId +
                       "\nТур:" + this.QualityTour+ "\nСтрана:" + 
                       this.Destination + "\nДата: "+ 
                       this.Date + "\nОплата: "+ this.Pay + " картой\n");

        }
        public void Payment()
        {
            Console.Write("\nВведите номер карты: ");
            string card=Console.ReadLine();
            System.Threading.Thread.Sleep(1000);
            Console.Write("Клиент с номером карты {0} найден\n",card);

        }
    }

    public class EWalletPayment : PersonalData,IPaymentStrategy
    {
        public EWalletPayment(string clientName, string clientSurname, string passportId, string qualitytour, string destination, DateTime date, string pay) : base(clientName, clientSurname, passportId, qualitytour, destination, date, pay)
        {
            Console.Write("\nИмя:" + this.ClientName + "\nФамилия: "
                       + this.ClientSurname +
                       "\nНомер паспорта: " +
                       this.PassportId +
                       "\nТур:" + this.QualityTour + "\nСтрана:" +
                       this.Destination + "\nДата: " +
                       this.Date + "\nОплата: " + this.Pay + " электронным кошельком\n");

        }
        public void Payment()
        {
            Console.Write("\nВведите номер электронного кошелька: ");
            string card = Console.ReadLine();
            System.Threading.Thread.Sleep(1000);
            Console.Write("Клиент с номером кошелька {0} найден\n", card);

        }
    }

    public class PaymentContext
    {
        private IPaymentStrategy paymentStrategy;

        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            this.paymentStrategy = strategy;
        }
        public void payment()
        {
            paymentStrategy.Payment();
        }
    }
}
