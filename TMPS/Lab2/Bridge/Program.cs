using System;


namespace Bridge
{
    //реализатор моста
    public interface IAccount
    {
        IAccount OpenAccount();
        void accountType();
    }

    //concrete implementation
    //конкретный класс
    public class SavingAccount : IAccount
    {
        public void accountType()
        {
            Console.WriteLine("Это сберегательный счет!!!");
         
        }

        public IAccount OpenAccount()
        {
            Console.WriteLine("Открыт: сберегательный счет!!!");
            return new SavingAccount();
        }
    }

    //конкретный класс
    public class CurrentAccount : IAccount
    {
        public void accountType()
        {
            Console.WriteLine("Это текущий счет!!!");

        }

        public IAccount OpenAccount()
        {
            Console.WriteLine("Открыт: текущий счет!!!");
            return new CurrentAccount();
        }
    }

    //abstraction
    public abstract class Bank
    {
        protected IAccount account;
        public Bank(IAccount account)
        {
            this.account = account;
        }
        public abstract IAccount OpenAccount();
    }

    //первая абстракция(уточненная)
    public class MaibBank : Bank
    {
        public MaibBank(IAccount account) : base(account)
        {
            Console.WriteLine("Добро пожаловать в банк MAIB!");
        }
        public override IAccount OpenAccount()
        {
            Console.WriteLine("Открыт ваш счет в банке MAIB");
            return account;
        }
    }

    //вторая абстракция
    public class VictoriaBank : Bank
    {
        public VictoriaBank(IAccount account) : base(account)
        {
            Console.WriteLine("Добро пожаловать в Victoria Bank!");
        }
        public override IAccount OpenAccount()
        {
            Console.WriteLine("Открыт ваш счет в банке Victoria Bank");
            return account;
        }
    }

   
    class Program
    {
        static void Main()
        {
            Bank maib = new MaibBank(new CurrentAccount());
            IAccount current = maib.OpenAccount();
            current.accountType();
            Console.WriteLine("===============================================================");
            Bank victoria = new VictoriaBank(new SavingAccount());
            IAccount saving = victoria.OpenAccount();
            saving.accountType();
            Console.ReadKey();
        }
    }
}
