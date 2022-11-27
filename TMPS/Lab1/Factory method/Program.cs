using System;


namespace FactoryMethod1
{
    class Program
    {
        static void Main(string[] args)
        {
            Delivery delivery = new LinellaDelivery("Олег", "Рублев", "Студенческая 1/1");
            delivery.Create();

            Delivery delivery1 = new Nr1Delivery("Валерий","Гуцу", "Студенческая 1/2");
            delivery1.Create();

            delivery = new LinellaDelivery("Лариса", "Милая", "Штефан чел Маре 2");
            delivery.Create();

            Console.ReadKey();
        }

        
        abstract class Delivery
        {
          
            public string ClientName { get; set; }
            public string ClientSurname { get; set; }
            public string ClientAddress { get; set; }
            


            public Delivery(string clientName, string clientSurname, string clientAddress)
            {
                ClientName = clientName;
                ClientSurname = clientSurname;
                ClientAddress = clientAddress;

            }
           
            // фабричный метод
            abstract public DeliveryMarket Create();
        }

        class LinellaDelivery : Delivery
        {
            public LinellaDelivery(string clientName, string clientSurname, string clientAddress) : base(clientName,clientSurname,clientAddress)
            {
                Console.Write(this.ClientName + " "
                            + this.ClientSurname + 
                            " по адресу " + 
                            this.ClientAddress + 
                            " ожидает доставку!\n");
            }

            public override DeliveryMarket Create()
            {
                return new DeliveryFromLinella();
            }
            
        }

        class Nr1Delivery : Delivery
        {
            public Nr1Delivery(string clientName, string clientSurname, string clientAddress) : base(clientName, clientSurname, clientAddress)
            {
                Console.Write(this.ClientName + " "
                            + this.ClientSurname +
                            " по адресу " +
                            this.ClientAddress +
                            " ожидает доставку!\n");

            }

            public override DeliveryMarket Create()
            {
                return new DeliveryFromN1();
            }
        }

        abstract class DeliveryMarket
        {

        }

        class DeliveryFromLinella : DeliveryMarket
        {
            public DeliveryFromLinella()
            {
                Console.WriteLine("Доставочка из Линеллы была выполнена!!\n");
            }
        }
        class DeliveryFromN1 : DeliveryMarket
        {
            public DeliveryFromN1()
            {
                Console.WriteLine("Доставочка из магазина Номер Один была выполнена!! \n");
            }
        }
    }
}
