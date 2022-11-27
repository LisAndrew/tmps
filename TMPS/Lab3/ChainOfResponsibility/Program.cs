using System;


namespace ChainOfResponsibility
{
    public class Program
    {
        public static void Main()
        {
            
            Approver larry = new SefOfDepartment();
            Approver sam = new DeputyDean();
            Approver tammy = new Dean();
            larry.SetSuccessor(sam);
            sam.SetSuccessor(tammy);
            Statement p = new Statement(10, "отчисление");
            larry.ProcessRequest(p);
            p = new Statement(20, "распечатка важного документа");
            larry.ProcessRequest(p);
            p = new Statement(30, "неточности в расписании");
            larry.ProcessRequest(p);
            Console.ReadKey();
        }
    }
 
    
    public abstract class Approver
    {
        protected Approver successor;
        public void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }
        public abstract void ProcessRequest(Statement statement);
    }
  
    public class SefOfDepartment : Approver
    {
        public override void ProcessRequest(Statement statement)
        {
            if (statement.Purpose == "распечатка важного документа")
            {
                Console.WriteLine("{0} одобрил запрос# {1}",
                    this.GetType().Name, statement.Number);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(statement);
            }
        }
    }

    public class DeputyDean : Approver
    {
        public override void ProcessRequest(Statement statement)
        {
            if (statement.Purpose =="неточности в расписании")
            {
                Console.WriteLine("{0} одобрил запрос# {1}",
                    this.GetType().Name, statement.Number);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(statement);
            }
        }
    }
  
    public class Dean : Approver
    {
        public override void ProcessRequest(Statement statement)
        {
            if (statement.Purpose == "отчисление")
            {
                Console.WriteLine(
                   "Запрос# {0} требует дополнительного собрания!",
                   statement.Number);
            }
           
        }
    }

    public class Statement
    {
        int number;
        string purpose;
       
        public Statement(int number, string purpose)
        {
            this.number = number;
            this.purpose = purpose;
        }
        
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
     
      
        public string Purpose
        {
            get { return purpose; }
            set { purpose = value; }
        }
    }
}
