using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Models
{
    //реализатор моста
    public interface IAccount
    {
        
        IAccount CreateAccount();
        double CreateDiscount();

        
    }

    //concrete implementation
    //конкретный класс
    public class DiscountAccount : IAccount
    {
        public double discount = 0.25;
        
        public IAccount CreateAccount()
        {
            Console.WriteLine("Регистрация прошла успешно!");
            return new DiscountAccount();
        }
        public double CreateDiscount()
        {
            Console.WriteLine("Подсчитываем скидку!\nПоздравляем, у вас есть скидка на первый тур - 25%!!");
            return discount;
        }

      
    }

    //конкретный класс
    public class RegularAccount : IAccount
    {
        public double discount = 0.1;
        public IAccount CreateAccount()
        {
            Console.WriteLine("Регистрация прошла успешно!");
            return new RegularAccount();
        }
        public double CreateDiscount()
        {
            return discount;
        }

    }

    public abstract class Person
    {
        protected IAccount account;
        public Person(IAccount account)
        {
            this.account = account;
        }
        public abstract IAccount CreateAccount();
    }

    //первая абстракция(уточненная)
    public class NaturalPerson : Person
    {
        
        public NaturalPerson(IAccount account) : base(account)
        {
            Console.WriteLine("\nОбрабатываем данные!");
        }
        public override IAccount CreateAccount()
        {
            
            return account;
        }
        
    }

    //вторая абстракция
    public class LegalPerson : Person
    {
        public LegalPerson(IAccount account) : base(account)
        {
            Console.WriteLine("\nОбрабатываем данные!");
        }
        public override IAccount CreateAccount()
        {
            return account;
        }
    }

}
