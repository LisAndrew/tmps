using System;
using System.Collections.Generic;


namespace Object_Pool
{
    class Storage<T> where T : new()
    {
        private static List<T> _availableEquipment = new List<T>();
        private List<T> _inUseEquipment = new List<T>();

        public int counter = 0;
        private int MaxTotalObjects;

        private static Storage<T> instance = null;

        public static Storage<T> GetInstance()
        {
            if (instance == null)
            {
                instance = new Storage<T>();
            }
            else
            {
                return instance;
            }
            return instance;
        }

        public T GiveEquipmentWorker()
        {
            if (_availableEquipment.Count != 0 && _availableEquipment.Count < 10)
            {
                T item = _availableEquipment[0];
                _inUseEquipment.Add(item);
                _availableEquipment.RemoveAt(0);
                counter--;
                return item;
            }
            else
            {
                T obj = new T();
                _inUseEquipment.Add(obj);
                return obj;
            }
        }

        public void ReturnEquipmentToStorage(T item)
        {
            if (counter <= MaxTotalObjects)
            {
                _availableEquipment.Add(item);
                counter++;
                _inUseEquipment.Remove(item);
            }
            else
            {
                Console.WriteLine("To much object in pool!");
            }
        }

        public void SetMaxPoolSize(int settingPoolSize)
        {
            MaxTotalObjects = settingPoolSize;
        }
    }
    interface IWorkSpace
    {
        void IfWorkerWasEmployed();
        void IfWorkerWasFired();
    }

    class WorkSpace : IWorkSpace
    {
        public void IfWorkerWasEmployed()
        {
            Console.WriteLine("Сотрудник нанят и работает");
        }

        public void IfWorkerWasFired()
        {
            Console.WriteLine("Сотрудник уволен");
        }
    }
    class Store
    {
        public int workers;
        public Storage<WorkSpace> objPool;

        public void employWorker()
        {
            workers++;
        }

        public void OrderEquipment()
        {
            objPool = Storage<WorkSpace>.GetInstance();
            objPool.SetMaxPoolSize(10);
        }

        public int employees()
        {
            return workers;
        }

        public void FireAnEmployee(WorkSpace obj)
        {
            workers--;
            objPool.ReturnEquipmentToStorage(obj);
        }

        public void EmployOrFired(WorkSpace obj, bool ifEmployWorker)
        {
            if (ifEmployWorker == true)
            {
                obj.IfWorkerWasEmployed();
            }
            else if (ifEmployWorker == false)
            {
                obj.IfWorkerWasFired();
            }
        }

      
    }

    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            store.employWorker();
            store.OrderEquipment();
            WorkSpace obj = store.objPool.GiveEquipmentWorker();
            Console.WriteLine("Количество оборудования в складе: " + store.objPool.counter);
            store.EmployOrFired(obj, true);
            Console.WriteLine("Количество сотрудников: "+ store.workers+"\n");

            store.employWorker();
            store.OrderEquipment();
            WorkSpace obj2 = store.objPool.GiveEquipmentWorker();
            Console.WriteLine("Количество оборудования в складе: " + store.objPool.counter);
            store.EmployOrFired(obj2, true);
            Console.WriteLine("Количество сотрудников:"+ store.workers + "\n");

            store.FireAnEmployee(obj);
            Console.WriteLine("Количество оборудования в складе: " + store.objPool.counter);
            store.EmployOrFired(obj, false);
            Console.WriteLine("Количество сотрудников: "+ store.workers + "\n");

            store.FireAnEmployee(obj);
            Console.WriteLine("Количество оборудования в складе: " + store.objPool.counter);
            store.EmployOrFired(obj2, false);
            Console.WriteLine("Количество сотрудников: "+ store.workers + "\n");


            Console.ReadKey();
        }
    }

}

