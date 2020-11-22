using System;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer { Id = 1, LastName = "Yurdakul", Age = 35 };
            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);
           

            Console.ReadLine();
        }
    }
    [ToTable("Customer")]
    class Customer
    {
        public int Id { get; set; }
        [RequiredProperty]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

    }
    class CustomerDal
    {
        [Obsolete("Don't Use")]
        public void Add(Customer customer)
        {
            Console.WriteLine("{0} {1} {2} {3}",customer.Id,customer.FirstName,customer.LastName,customer.Age);
        }
        
        public void AddNew(Customer customer)
        {
            Console.WriteLine("{0} {1} {2} {3}", customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    class RequiredPropertyAttribute:Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Class)]
    class ToTableAttribute :Attribute
    {
        private string _tableName;
        public ToTableAttribute(string tableName)
        {
            _tableName = tableName;
        }
    }

    
}
