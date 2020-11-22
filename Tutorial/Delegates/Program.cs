using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        public delegate void MyDelegate();
        public delegate void MyDelegate2(string text);

        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            //customerManager.SendMessage();
            //customerManager.ShowAlert();

            //MyDelegate myDelegate = customerManager.SendMessage;
            //myDelegate += customerManager.ShowAlert;
            //myDelegate.Invoke();
            MyDelegate2 myDelegate2 = customerManager.SendMessage2;
            myDelegate2.Invoke("Caglar");
           
            Console.ReadLine();
        }
        public class CustomerManager
        {
            public void SendMessage()
            {
                Console.WriteLine("Hello!");
            }
            public void SendMessage2(string message)
            {
                Console.WriteLine(message);
            }
            public void ShowAlert()
            {
                Console.WriteLine("Be Careful!");
            }
        }
    }
}
