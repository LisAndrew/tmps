using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Models
{
    //subsystem1
    public class TourDetails
    {
        public void GetTourDetails()
        {
            Console.WriteLine("Собираем данные!");
            
        }
    }
    //subsystem2
    public class Payment
    {
        public void MakePayment()
        {
            Console.Write("\nОплата прошла успешно!!!");
        }
    }

    //subsystem3
    public class Invoice
    {
        public void Sendinvoice()
        {
            Console.Write("\nСчет отправлен успешно!!");
        }
    }

    //facade
    public class Order
    {
        public void PlaceOrder()
        {

            TourDetails tour= new TourDetails();
            tour.GetTourDetails();
            Payment payment = new Payment();
            payment.MakePayment();
            Invoice invoice = new Invoice();
            invoice.Sendinvoice();
            Console.WriteLine("\nЗаказ успешно размещен!");
        }
    }
}
