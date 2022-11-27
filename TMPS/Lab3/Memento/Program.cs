using System;


namespace Memento
{
 
    public class Originator
    {
        string state;
        public string State
        {
            get { return state; }
            set
            {
                state = value;
                Console.WriteLine("State = " + state);
            }
        }
        // Создаем мементо 
        public Memento CreateMemento()
        {
            return new Memento(state);
        }
        // Восстанавливает исходное состояние
        public void SetMemento(Memento memento)
        {
            Console.WriteLine("Restoring state...");
            State = memento.State;
        }
    }
  
    public class Memento
    {
        string state;
     
        public Memento(string state)
        {
            this.state = state;
        }
        public string State
        {
            get { return state; }
        }
    }

    public class Caretaker
    {
        Memento memento;
        public Memento Memento
        {
            set { memento = value; }
            get { return memento; }
        }
    }

    public class Program
    {
        public static void Main()
        {
            Originator o = new Originator();
            o.State = "On";
            // Сохраняем внутреннее состояние
            Caretaker c = new Caretaker();
            c.Memento = o.CreateMemento();
            o.State = "Off";
            // Восстанавливаем сохраненное состояние
            o.SetMemento(c.Memento);
            Console.ReadKey();
        }
    }
}
