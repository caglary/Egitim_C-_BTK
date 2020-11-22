using Northwind.Entities.Concrete;
using Nortwind.Entities.Concrete;
using System.Data.Entity;

namespace Northwind.DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categoried { get; set; }


    }
}
