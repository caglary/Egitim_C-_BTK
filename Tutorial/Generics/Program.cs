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
        }
    }
    interface IProduct:IRepository<Product>
    {
      
        
    }
    interface IRepository<T>
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
}
