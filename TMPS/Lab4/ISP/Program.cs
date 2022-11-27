using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Segregation
{  //плохой способ
    interface IMessage
    {
        void Send();
        string Text { get; set; }
        string Subject { get; set; }
        string ToAddress { get; set; }
        string FromAddress { get; set; }
    }
    class EmailMessage : IMessage
    {
        public string Subject { get; set; } = "";
        public string Text { get; set; } = "";
        public string FromAddress { get; set; } = "";
        public string ToAddress { get; set; } = "";

        public void Send() => Console.WriteLine($"Отправляем Email-сообщение: {Text}");
    }
    class SmsMessage : IMessage
    {
        public string Text { get; set; } = "";
        public string FromAddress { get; set; } = "";
        public string ToAddress { get; set; } = "";

        public string Subject
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void Send() => Console.WriteLine($"Отправляем Sms-сообщение: {Text}");
    }



    //best practice
    interface IMessage2
    {
        void Send();
        string ToAddress { get; set; }
        string FromAddress { get; set; }
    }
   
    interface ITextMessage : IMessage2
    {
        string Text { get; set; }
    }

    interface IEmailMessage : ITextMessage
    {
        string Subject { get; set; }
    }

 
    class EmailMessage2 : IEmailMessage
    {
        public string Text { get; set; } = "";
        public string Subject { get; set; } = "";
        public string FromAddress { get; set; } = "";
        public string ToAddress { get; set; } = "";

        public void Send() => Console.WriteLine("Отправляем по Email сообщение: {0}", Text);
    }

    class SmsMessage2 : ITextMessage
    {
        public string Text { get; set; } = "";
        public string FromAddress { get; set; } = "";
        public string ToAddress { get; set; } = "";
        public void Send() => Console.WriteLine("Отправляем по Sms сообщение: {0}",Text);
    }
    class Program
    {
        static void Main()
        {
            SmsMessage sms = new SmsMessage()
            {
                Text = ("как дела?")
            };
            sms.Send();

            Console.WriteLine("===============================");
            SmsMessage2 sms2 = new SmsMessage2
            {
                Text = ("погуляем?")
            };
            sms2.Send();
            Console.ReadKey();
        }
    }
}
