using Northwind.Entities.Concrete;
using Nortwind.Entities.Concrete;
using System.Collections.Generic;

namespace Northwind.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetProductsByCategory(int categoryId);
        List<Product> GetProductsByProductName(string productName);
    }
}
