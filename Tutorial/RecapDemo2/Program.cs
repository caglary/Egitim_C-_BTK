using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecapDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new DatabaseLogger() );
           
            customerManager.Add();
            Console.ReadLine();
        }
    }
    class CustomerManager
    {
        private ILogger Logger { get; set; }
        public CustomerManager(ILogger loggers)
        {
            Logger = loggers;
        }
       
        public void Add()
        {
            Logger.log();
            
            Console.Write("Customer added!");

        }
    }
    class DatabaseLogger:ILogger
    {
        public void log()
        {
            Console.WriteLine("Logged to Database!");
        }
    }
    class FileLogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("Logged to File!");

        }
    }
    class SmsLogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("Logged to Sms!");

        }
    }
    interface ILogger
    {
        void log();
    }
}
