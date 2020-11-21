using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayList();
            List<string> cities = new List<string>();
            cities.Add("Ankara");
            foreach (var item in cities)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(cities.Contains("Ankara"));
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer { Name = "caglar" });
           

            var customer2 = new Customer { Name = "Eda" };
            customers.Add(customer2);
            customers.AddRange(new Customer[2]
            {
                new Customer{Name="Salih"},
                new Customer{Name="Mehmet"}
            });
            var count = customers.Count;

            Console.WriteLine(count);
            customers.Clear();
            count = customers.Count;

            Console.WriteLine(count);

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.Name);
            }
            var index = customers.IndexOf(customer2);
            Console.WriteLine("index :{0}",index);

            Console.ReadLine();
        }

        private static void ArrayList()
        {
            ArrayList cities = new ArrayList();
            cities.Add("Ankara");
            cities.Add("Adana");
            cities.Add("İstanbul");
            cities.Add(1);

            foreach (var item in cities)
            {
                Console.WriteLine(item);

            }
        }

    }
    class Customer
    {
        public string Name { get; set; }
    }
}
