using System;


namespace Facade
{
    //subsystem1
    public class Product
    {
        public void GetProductDetails()
        {
            Console.WriteLine("Получение сведений о продукте");
        }
    }
    //subsystem2
    public class Payment
    {
        public void MakePayment()
        {
            Console.WriteLine("Оплата прошла успешно");
        }
    }

    //subsystem3
    public class Invoice
    {
        public void Sendinvoice()
        {
            Console.WriteLine("Счет отправлен успешно");
        }
    }

    //facade
    public class Order
    {
        public void PlaceOrder()
        {
            Console.WriteLine("Размещаем заказ");
            Product product = new Product();
            product.GetProductDetails();
            Payment payment = new Payment();
            payment.MakePayment();
            Invoice invoice = new Invoice();
            invoice.Sendinvoice();
            Console.WriteLine("Заказ успешно размещен");
        }
    }

    class Program
    {
        static void Main()
        {
            Order order = new Order();
            order.PlaceOrder();
            Console.ReadKey();
        }
    }
    
}
    

