using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities utilities = new Utilities();
            List<string> result = utilities.BuildList("İzmir", "Adana", "İstanbul");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            List<Customer> customers = utilities.BuildList<Customer>(
                new Customer { FirstName = "Çağlar" },
                new Customer { FirstName = "Eda" },
                new Customer { FirstName = "Muhammed Emin" });
            foreach (var item in customers)
            {
                Console.WriteLine(item.FirstName);
            }
            Console.ReadLine();
        }
    }
    class Customer
    {
        public string FirstName { get; set; }
    }
    interface IProduct:IRepository<Product>
    {
      
        
    }
    interface IRepository<T> where T:class ,new ()
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T product);
        void Delete(T product);
        void Update(T product);
    }
    class Product : IProduct
    {
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

    }

    class Utilities
    {
        public List<T> BuildList<T>(params T[] items)
        {
            return new List<T>(items);
        }
    }


}
