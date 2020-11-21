using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomerManager customer = new CustomerManager();
            customer.Add();
            customer.List();

            EmployeeManager employeeManager = new EmployeeManager(new DatabaseLogger());
            employeeManager.Add();

            PersonManager personManager = new PersonManager("product");
            personManager.add();

            Teacher.Number = 10;
            Utilities.Validate();

            Console.ReadLine();
        }
    }
    class CustomerManager
    {
        private int _count = 15;
        public CustomerManager(int count)
        {
            _count = count;
        }
        public CustomerManager()
        {

        }
        public void List()
        {
            Console.WriteLine("Listed! {0} items", _count);
        }
        public void Add()
        {
            Console.WriteLine("Added!");
        }
    }
    class Product
    {
        public Product()
        {

        }
        private int _id;
        private string _name;
        public Product(int id, string name)
        {
            _id = id;
            _name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
    interface ILogger
    {
        void log();
    }
    class DatabaseLogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("Log the Database");
        }
    }
    class FileLogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("Log the File");
        }
    }
    class EmployeeManager
    {
        ILogger _logger;
        public EmployeeManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Add()
        {
            _logger.log();
            Console.WriteLine("Added! ");
        }
    }

    class BaseClass
    {
        private string _entity;
        public BaseClass(string entity)
        {
            _entity = entity;

        }
        public void Message()
        {
            Console.WriteLine("{0} message",_entity);
        }

    }
    class PersonManager : BaseClass
    {
        public PersonManager(string entity):base(entity)
        {

        }
        public void add()
        {
            Console.WriteLine("Added!");
            Message();
        }
    }

    static class Teacher
    {
        public static int Number { get; set; }
    }
    static class Utilities
    {
        public static void Validate()
        {
            Console.WriteLine("Validation is done");
        }
    }

    class Manager
    {
        public static void DoSomething()
        {
            Console.WriteLine("Done");
        }
        public void DoSomething2()
        {
            Console.WriteLine("Done 2");
        }
    }



}
