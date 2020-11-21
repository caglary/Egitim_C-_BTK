using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Private : Tanımlandığı block içerisinde kullanılır. 
            //Protected : Private özelliğini içerir.Buna ek olarak
            //inheritance yapıldığında kullanılabilir.
            //internal: Aynı proje  içerisinde kullanılır.
            //public : heryerde ...

        }
    }
    class  Customer
    {
        int id;
        public void Save()
        {
            
        }
    }
    class Student
    {
        public void Save()
        {
            
        }
    }
    class Course //  default of this class is Internal.
    {
        public string Name { get; set; }

    }


}
